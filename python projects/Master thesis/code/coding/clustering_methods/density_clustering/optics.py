from coding.clustering_methods.density_clustering.helpers import estimate_density_parameters
from sklearn.cluster import OPTICS


def optics(training_data, test_data, metric='euclidean', n_jobs=-1):
    eps, min_pts = estimate_density_parameters(training_data, metric)

    model = OPTICS(min_samples=min_pts, metric=metric, n_jobs=n_jobs).fit(training_data)
    labels = model.predict(test_data)

    return labels
