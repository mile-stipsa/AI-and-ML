import math

from scipy.stats import entropy
from scipy.spatial.distance import cdist
from sklearn.metrics.cluster import contingency_matrix

import numpy as np
from joblib import Parallel
from joblib import delayed

"Entropy methods"


def probability(labels):
    unique, count = np.unique(labels, return_counts=True, axis=0)
    probabilities = count / len(labels)
    return probabilities


def data_entropy(labels):
    probabilities = probability(labels)
    return entropy(probabilities)


def joint_entropy(labels_true, labels_predicted):
    joint = np.c_[labels_predicted, labels_true]
    probabilities = probability(joint)
    return entropy(probabilities)


"End entropy methods"

"Pairwise methods"


def c_matrix(label_true, label_predicted):
    return np.matrix(contingency_matrix(label_true, label_predicted))


def pairwise_variables(labels_true, labels_predicted):
    matrix = c_matrix(labels_true, labels_predicted)
    elements = np.sum(matrix)
    same_cluster = np.sum(matrix, axis=0)
    same_cluster = same_cluster.T
    same_partition = np.sum(matrix, axis=1)
    N = (elements * (elements - 1)) / 2

    TP_array = [math.comb(x, 2) for x in np.nditer(matrix)]
    TP = np.sum(TP_array)

    FN_array = [math.comb(int(i), 2) for i in iter(same_partition)]
    FN = np.sum(FN_array) - TP

    FP_array = [math.comb(int(i), 2) for i in iter(same_cluster)]
    FP = np.sum(FP_array) - TP

    TN = N - (TP + FP + FN)

    return {'TP': TP, 'FN': FN, 'FP': FP, 'TN': TN, 'N': N}


"End pairwise methods"

"Internal helpers methods"


def n_in(labels, n_jobs=-1, verbose=1):
    def val(n):
        return count[n] * count[(n - 1)]

    unique, count = np.unique(labels, return_counts=True, axis=0)
    cluster_numbers = len(unique)
    res = Parallel(n_jobs=n_jobs, verbose=verbose)(delayed(val)(i) for i in range(cluster_numbers))
    value = np.sum(res) / 2
    return value


def n_out(labels, n_jobs=-1, verbose=1):
    def val(i, j):
        return count[i] * count[j]

    unique, count = np.unique(labels, return_counts=True, axis=0)
    cluster_numbers = len(unique)
    res = Parallel(n_jobs=n_jobs, verbose=verbose)(
        delayed(val)(i, j) for i in range(cluster_numbers - 1) for j in range(i + 1, cluster_numbers))
    value = np.sum(res)
    return value


def w_in_separate(labels, distance_matrix, n_jobs=-1, verbose=2):
    clusters = np.unique(labels)
    cluster_numbers = len(clusters)

    iner_cluster = np.empty(cluster_numbers, dtype=object)
    indexes = np.empty(cluster_numbers, dtype=object)

    for i in range(cluster_numbers):
        indexes[i] = np.where(labels == clusters[i])[0]

    def val(m):
        return distance_matrix[m[0],m[1]]

    for cluster, index in enumerate(indexes):
        mesh = np.array(np.meshgrid(index, index)).T.reshape(-1, 2)
        res = Parallel(n_jobs=n_jobs, verbose=verbose)(delayed(val)(j) for j in mesh)
        iner_cluster[cluster] = np.sum(res)

    return iner_cluster


def w_in(iner_clusters_sums):
    iner_clusters_sum = np.sum(iner_clusters_sums)
    return iner_clusters_sum / 2


def w_out_separate(labels, distance_matrix, n_jobs=-1, verbose=2):
    clusters = np.unique(labels)
    cluster_numbers = len(clusters)

    inter_cluster = np.zeros(shape=(cluster_numbers, cluster_numbers))
    indexes = np.empty(cluster_numbers, dtype=object)

    for i in range(cluster_numbers):
        indexes[i] = np.where(labels == clusters[i])[0]

    def val(m):
        return distance_matrix[m[0], m[1]]

    for i in range(cluster_numbers - 1):
        for j in range(i + 1, cluster_numbers):
            mesh = np.array(np.meshgrid(indexes[i], indexes[j])).T.reshape(-1, 2)
            res = Parallel(n_jobs=n_jobs, verbose=verbose)(
                delayed(val)(m) for m in mesh)
            res = np.sum(res)
            inter_cluster[i, j] = res
            inter_cluster[j, i] = res

    return inter_cluster


def w_out(inter_clusters_sums):
    inter_clusters_sum = np.sum(inter_clusters_sums)
    return inter_clusters_sum / 2


def clusters_volume(w_ins_separate, w_outs_separate):
    cluster_numbers = len(w_ins_separate)
    w_outs_c = np.empty(cluster_numbers)
    values = np.empty(cluster_numbers)
    for i in range(cluster_numbers):
        values[i] = w_ins_separate[i] + np.sum(w_outs_separate[i])
        w_outs_c[i] = np.sum(w_outs_separate[i])

    return values, w_outs_c


"End internal helpers methods"


def all_internal_values(data, labels, metric='euclidean', n_jobs=-1, verbose=2):
    distance_matrix = cdist(data, data, metric)
    inter_clusters_sums = w_out_separate(labels, distance_matrix, n_jobs, verbose)
    w_in_separate_values = w_in_separate(labels, distance_matrix, n_jobs, verbose)
    volumes, w_out_separate_values = clusters_volume(w_in_separate_values, inter_clusters_sums)

    n_in_value = n_in(labels, n_jobs, verbose)
    n_out_value = n_out(labels, n_jobs, verbose)

    w_in_value = w_in(w_in_separate_values)
    w_out_value = w_out(inter_clusters_sums)

    return n_in_value, n_out_value, w_in_value, w_out_value, w_in_separate_values, w_out_separate_values, volumes
