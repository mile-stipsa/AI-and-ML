from sklearn_extra.cluster import KMedoids


def kmedoids(training_data, test_data, n_clusters=8, metric='euclidean'):
    model = KMedoids(n_clusters=n_clusters, metric=metric).fit(training_data)
    labels = model.predict(test_data)
    return labels
