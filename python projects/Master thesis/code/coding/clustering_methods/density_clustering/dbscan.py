from sklearn.cluster import DBSCAN
from coding.clustering_methods.density_clustering.helpers import estimate_density_parameters


def db_scan(training_data, test_data, metric='euclidean', n_jobs=-1):
    eps, min_pts = estimate_density_parameters(training_data, metric)
    model = DBSCAN(eps, min_samples=min_pts, metric=metric, n_jobs=n_jobs).fit(training_data)
    labels = model.predict(test_data)
    return labels
