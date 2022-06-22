import math

import Categorical_similarity_measures as csm
import numpy as np


def E(x, y, fsv):
    hs = np.size(x, axis=0)
    agreement = np.zeros(hs, dtype='int')
    for k in range(hs):
        if x[k] == 1 and y[k] == 1:
            agreement[k] = 1

    return np.matmul(fsv, agreement)


def F(x, y, fsv, cum, features_number):
    hs = np.size(x, axis=0)
    v = 0
    agreement = np.zeros(hs, dtype='int')
    for k in range(features_number):
        for t in range(v, cum[k]):
            if x[t] == 0 and y[t] == 1:
                for val in range(v, cum[k]):
                    agreement[val] = 1
        v = cum[k]

    return np.matmul(agreement, fsv)


def overlap_similarity(x, y):
    agreement = np.sum(np.equal(x, y))
    if agreement != 0:
        return 1. - 1. / np.size(x, axis=0) * agreement
    else:
        return 1.


def eskin_similarity(x, y, unique):
    s = np.size(x, axis=0)
    agreement = 0
    for k in range(s):
        if x[k] == y[k]:
            agreement += 1
        else:
            agreement = unique[k] ** 2 / (unique[k] ** 2 + 2)

    return s / agreement - 1


def of_similarity(x, y, frequency, data_size):
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    s = np.size(x, axis=0)
    agreement = 0
    for k in range(s):
        c = x[k] - 1
        d = y[k] - 1
        if x[k] == y[k]:
            agreement += 1.0
        else:
            agreement += 1 / (1 + np.log(data_size / frequency[c][k]) * np.log(data_size / frequency[d][k]))

    return s / agreement - 1.0


def iof_similarity(x, y, frequency):
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    s = np.size(x, axis=0)
    agreement = 0
    for k in range(s):
        c = x[k] - 1
        d = y[k] - 1
        if x[k] == y[k]:
            agreement += 1.0
        else:
            agreement += 1 / (1 + (np.log(frequency[c][k]) * np.log(frequency[d][k])))

    return s / agreement - 1.0


def goodall1_similarity(x, y, frequency, data_size):
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    frequency_relative = frequency / data_size
    frequency_relative2 = frequency_relative ** 2
    agreement = 0
    s = np.size(x, axis=0)
    for k in range(s):
        c = x[k] - 1
        if x[k] == y[k]:
            logic = frequency_relative[:, k] <= frequency_relative[c][k]
            agreement += 1 - sum(frequency_relative2[:, k] * logic)

    if x is y:
        return 0
    else:
        return 1.0 - agreement / s


def goodall2_similarity(x, y, frequency, data_size):
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    frequency_relative = frequency / data_size
    frequency_relative2 = frequency_relative ** 2
    agreement = 0
    s = np.size(x, axis=0)
    for k in range(s):
        c = x[k] - 1
        if x[k] == y[k]:
            logic = frequency_relative[:, k] >= frequency_relative[c][k]
            agreement += 1 - sum(frequency_relative2[:, k] * logic)

    if x is y:
        return 0
    else:
        return 1.0 - agreement / s


def goodall3_similarity(x, y, frequency, data_size):
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    frequency_relative = frequency / data_size
    agreement = 0
    s = np.size(x, axis=0)
    for k in range(s):
        c = x[k] - 1
        if x[k] == y[k]:
            agreement += 1 - frequency_relative[c, k] ** 2

    if x is y:
        return 0
    else:
        return 1.0 - agreement / s


def goodall4_similarity(x, y, frequency, data_size):
    frequency_relative = frequency / data_size
    agreement = 0
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    s = np.size(x, axis=0)
    for k in range(s):
        c = x[k] - 1
        if x[k] == y[k]:
            agreement += frequency_relative[c, k] ** 2

    if x is y:
        return 0
    else:
        return 1.0 - agreement / s


def lin_similarity(x, y, frequency, data_size):
    s = np.size(x, axis=0)
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    frequency_relative = frequency / data_size

    agreement = 0
    weights = 0

    for k in range(s):
        c = x[k] - 1
        d = y[k] - 1
        if x[k] == y[k]:
            agreement += 2 * np.log(frequency_relative[c][k])
        else:
            agreement += 2 * np.log(frequency_relative[c][k] + frequency_relative[d][k])
        weights += np.log(frequency_relative[c][k]) + np.log(frequency_relative[d][k])
    if x is y:
        return 0
    else:
        return 1 / (1 / weights * agreement) - 1


def lin1_similarity(x, y, frequency, data_size):
    s = np.size(x, axis=0)
    x = np.asarray(x, dtype='int')
    y = np.asarray(y, dtype='int')
    frequency_relative = frequency / data_size
    frequency_log = np.log(frequency_relative)

    agreement = 0
    weights = 0

    for k in range(s):
        c = x[k] - 1
        d = y[k] - 1
        if x[k] == y[k]:
            logic = frequency_relative[:, k] == frequency_relative[c][k]
            agreement += sum(np.nan_to_num(logic * frequency_log[:, k]))
            weights += sum(np.nan_to_num(logic * frequency_log[:, k]))
        else:
            if frequency_relative[c][k] >= frequency_relative[d][k]:
                logic = np.logical_and(frequency_relative[:, k] >= frequency_relative[d][k],
                                       frequency_relative[:, k] <= frequency_relative[c][k])
                agreement += 2 * np.log(sum(logic * frequency_relative[:, k]))
                weights += sum(np.nan_to_num(logic * frequency_log[:, k]))
            else:
                logic = np.logical_and(frequency_relative[:, k] >= frequency_relative[c][k],
                                       frequency_relative[:, k] <= frequency_relative[d][k])
                agreement += 2 * np.log(sum(logic * frequency_relative[:, k]))
                weights += sum(np.nan_to_num(logic * frequency_log[:, k]))
    if x is y:
        return 0
    else:
        return 1 / (1 / weights * agreement) - 1


def ve_similarity(data):
    return csm.VE(data)


def vm_similarity(data):
    return csm.VM(data)


def s2_similarity(x, y, fsv, cum, features_number):
    e = E(x, y, fsv)
    f = F(x, y, fsv, cum, features_number)

    return 1 - e / (e + f)


distances = {
    'overlap': overlap_similarity,
    'eskin': eskin_similarity,
    'of': of_similarity,
    'iof': iof_similarity,
    'goodall1': goodall1_similarity,
    'goodall2': goodall2_similarity,
    'goodall3': goodall3_similarity,
    'goodall4': goodall4_similarity,
    'lin': lin_similarity,
    'lin1': lin1_similarity,
    's2': s2_similarity
}
