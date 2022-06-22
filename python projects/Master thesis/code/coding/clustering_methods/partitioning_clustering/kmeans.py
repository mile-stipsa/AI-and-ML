from sklearn.cluster import KMeans
from nltk.cluster import KMeansClusterer
from coding.similarity_measures.numerical_and_text.measures import get_distance_function
import numpy as np
from scipy.spatial.distance import mahalanobis as m


def kmeans(data, n_clusters=8, metric='euclidean', p=2):
    labels = KMeans(n_clusters=n_clusters, metric=metric, p=p).fit_predict(data)
    return labels


def kmeans_with_fit(training_data, test_data, n_clusters=8, metric='euclidean', p=2):
    model = KMeans(n_clusters=n_clusters, metric=metric, p=p).fit(training_data)
    labels = model.predict(test_data)
    return labels


def kmeans_nltk(data, n_clusters=8, metric='euclidean'):
    VI = np.linalg.inv(np.cov(data, rowvar=False))
    VI = np.atleast_2d(VI)

    def mahalanobis(u, v):
        return m(u, v, VI)

    if metric != 'mahalanobis':
        model = KMeansClusterer(n_clusters, distance=get_distance_function(metric))
    else:
        model = KMeansClusterer(n_clusters, distance=mahalanobis)

    labels = model.cluster(data, True)
    return labels
