from sklearn.cluster import Birch


def birch(data, n_clusters=8):
    model = Birch(n_clusters=n_clusters)
    labels = model.fit_predict(data)

    return labels
