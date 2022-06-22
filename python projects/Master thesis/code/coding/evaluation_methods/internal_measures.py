from sklearn.metrics import davies_bouldin_score
from sklearn.metrics import silhouette_score
from sklearn.metrics import silhouette_samples
from c_index import calc_c_index

import coding.evaluation_methods.helpers as h


def davies_bouldin_measure(data, labels):
    return davies_bouldin_score(data, labels)


def silhouette_mean_measure(data, labels, metric="euclidean"):
    return silhouette_score(data, labels, metric=metric)


def silhouette_samples_measure(data, labels, metric='euclidean'):
    return silhouette_samples(data, labels, metric=metric)


def c_index_measure(data, labels):
    if hasattr(data, 'values'):
        data = data.values

    return calc_c_index(data, labels)


def betacv_measure(n_in, n_out, w_in, w_out):
    numerator = w_in / n_in
    denumerator = w_out / n_out

    value = numerator / denumerator
    return value


def normalize_cut_measure(w_out_separate, volumes):
    v = h.np.divide(w_out_separate, volumes)
    value = h.np.sum(v)

    return value


def modularity_measure(w_in, w_out, w_in_separate, volumes):
    v_volume = 2 * (w_in + w_out)

    value1 = h.np.divide(w_in_separate, v_volume)
    value2 = h.np.divide(volumes, v_volume)
    value = h.np.subtract(value1, value2)
    value = h.np.power(value, 2)
    value = h.np.sum(value)

    return value


def dunn_measure(w_in_separate, w_out_separate):
    w_in_max = h.np.max(w_in_separate)
    w_out_min = h.np.min(w_out_separate)

    value = w_out_min / w_in_max

    return value
