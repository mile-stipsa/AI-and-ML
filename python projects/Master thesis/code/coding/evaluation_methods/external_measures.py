from sklearn.metrics import v_measure_score
from sklearn.metrics import rand_score
from sklearn.metrics import normalized_mutual_info_score
from sklearn.metrics import fowlkes_mallows_score
from sklearn.metrics import adjusted_rand_score
from sklearn.metrics import adjusted_mutual_info_score

import numpy as np
import coding.evaluation_methods.helpers as h
import math


def purity_measure(labels_true, labels_predicted):
    matrix = h.c_matrix(labels_true, labels_predicted)
    return np.sum(np.amax(matrix, axis=0)) / np.sum(matrix)


def f_measure(labels_true, labels_predicted):
    variables = h.pairwise_variables(labels_true, labels_predicted)
    precision = variables['TP']/(variables['TP']+variables['FP'])
    recall = variables['TP']/(variables['TP']+variables['FN'])
    value = 2*((precision*recall)/(precision+recall))
    return value


def conditional_entropy_measure(labels_true, labels_predicted):
    return h.joint_entropy(labels_true, labels_predicted) - h.data_entropy(labels_predicted)


def variation_of_information_measure(labels_true, labels_predicted):
    return conditional_entropy_measure(labels_true, labels_predicted) + conditional_entropy_measure(labels_predicted,
                                                                                                    labels_true)


def normalized_mutual_information_measure(labels_true, labels_predicted):
    return normalized_mutual_info_score(labels_true, labels_predicted)


def v_measure(labels_true, labels_predicted):
    return v_measure_score(labels_true, labels_predicted)


def jaccard_measure(labels_true, labels_predicted):
    variables = h.pairwise_variables(labels_true, labels_predicted)
    nominator = variables['TP']
    denominator = variables['TP']+variables['FN']+variables['FP']
    value = nominator/denominator
    return value


def rand_index_measure(labels_true, labels_predicted):
    return rand_score(labels_true, labels_predicted)


def fowlkes_mallows_measure(labels_true, labels_predicted):
    return fowlkes_mallows_score(labels_true, labels_predicted)


def adjusted_rand_index_measure(labels_true, labels_predicted):
    return adjusted_rand_score(labels_true, labels_predicted)


def adjusted_mutual_information_measure(labels_true, labels_predicted):
    return adjusted_mutual_info_score(labels_true, labels_predicted)


def discretized_hubert_statistic(labels_true, labels_predicted):
    variables = h.pairwise_variables(labels_true, labels_predicted)
    value = variables['TP'] / variables['N']
    return value


def normalized_discretized_hubert_statistic(labels_true, labels_predicted):
    variables = h.pairwise_variables(labels_true, labels_predicted)
    same_partition = (variables['TP']+variables['FN'])/variables['N']
    same_cluster = (variables['TP']+variables['FP'])/variables['N']

    numerator = variables['TP']/variables['N']-same_partition*same_cluster
    denominator = math.sqrt(same_partition*same_cluster*(1-same_partition)*(1-same_cluster))
    value = numerator/denominator

    return value
