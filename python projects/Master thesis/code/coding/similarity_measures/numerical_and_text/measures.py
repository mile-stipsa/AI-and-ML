from scipy.spatial import distance

distances = {
    'minkowski': distance.minkowski,
    'mahalanobis': '',
    'canberra': distance.canberra,
    'correlation': distance.correlation,
    'sqeuclidean': distance.sqeuclidean,
    'cosine': distance.cosine,
    'braycurtis': distance.braycurtis,
    'euclidean': distance.euclidean,
    'cityblock': distance.cityblock,
    'chebyshev': distance.chebyshev
}


def get_distance_function(metric='euclidean'):
    return distances[metric]
