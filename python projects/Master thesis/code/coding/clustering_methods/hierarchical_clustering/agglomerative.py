from sklearn.cluster import AgglomerativeClustering


def agglomerative(data, n_clusters=8, metric='euclidean', linkage='ward', categorical=False):
    model = AgglomerativeClustering(n_clusters=n_clusters, affinity=metric, linkage=linkage, compute_distances=True,
                                    categorical=categorical)
    labels = model.fit_predict(data)
    return labels
