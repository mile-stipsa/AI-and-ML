from coding.preprocessing.binary_and_categorical_and_numerical.preprocessing import *
from coding.similarity_measures.numerical_and_text.measures import *
from coding.clustering_methods.partitioning_clustering.kmeans import *
from coding.evaluation_methods.external_measures import *
from coding.evaluation_methods.internal_measures import *
from coding.evaluation_methods.helpers import all_internal_values
import numpy as np
import pandas as pd

columns_to_remove = ['stab', 'Class']

test_data = load_data('../../../../../datasets/numerical/electrical_grid/electrical_grid.csv')

"Labels preparations"
labels = test_data['Class']
labels = encode_class(labels, columns=['Class'])
labels = np.reshape(labels.values, newshape=(len(labels), ))
n_clusters = len(np.unique(labels))

"Test data extraction"
test_data = remove_columns(test_data, columns_to_remove)

"Training data resampling and extraction"
train_data = downsample_data(test_data, labels, column_name='Class')
train_data = remove_columns(train_data, ['Class'])
train_data = scale_data(train_data)

test_data = scale_data(test_data)

external_measures = {}
internal_measures = {}

for key, fun in distances.items():
    print(key)
    labels_predict = kmeans_with_fit(train_data, test_data, n_clusters, key)
    external = {
        'P': purity_measure(labels, labels_predict),
        'F': f_measure(labels, labels_predict),
        'CE': conditional_entropy_measure(labels, labels_predict),
        'VI': variation_of_information_measure(labels, labels_predict),
        'NMI': normalized_mutual_information_measure(labels, labels_predict),
        'V': v_measure(labels, labels_predict),
        'J': jaccard_measure(labels, labels_predict),
        'RI': rand_index_measure(labels, labels_predict),
        'FM': fowlkes_mallows_measure(labels, labels_predict),
        'ARI': adjusted_rand_index_measure(labels, labels_predict),
        'AMI': adjusted_mutual_information_measure(labels, labels_predict),
        'DHS': discretized_hubert_statistic(labels, labels_predict),
        'NDHS': normalized_discretized_hubert_statistic(labels, labels_predict)
    }

    n_in_value, n_out_value, w_in_value, w_out_value, w_in_separate_values, w_out_separate_values, volumes = all_internal_values(
        test_data, labels_predict)

    internal = {
        'DB': davies_bouldin_measure(test_data, labels_predict),
        'S': silhouette_mean_measure(test_data, labels_predict),
        'C': c_index_measure(test_data, labels_predict),
        'BCV': betacv_measure(n_in_value, n_out_value, w_in_value, w_out_value),
        'CUT': normalize_cut_measure(w_out_separate_values, volumes),
        'MOD': modularity_measure(w_in_value, w_out_value, w_in_separate_values, volumes),
        'DUNN': dunn_measure(w_in_separate_values, w_out_separate_values)
    }

    external_measures[key] = external
    internal_measures[key] = internal


ex = pd.DataFrame.from_dict(external_measures, orient='index')
inter = pd.DataFrame.from_dict(internal_measures, orient='index')

ex.to_csv('electrical_grid_external.csv')
inter.to_csv('electrical_grid_internal.csv')
