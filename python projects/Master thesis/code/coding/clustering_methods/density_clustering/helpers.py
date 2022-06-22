from sklearn.neighbors import NearestNeighbors
from kneed import KneeLocator
import numpy as np


def estimate_density_parameters(data, metric='minkowski', curve='convex', direction='increasing', n_jobs=-1):
    min_pts = 2*data.shape[1]

    model = NearestNeighbors(n_neighbors=min_pts, metric=metric, n_jobs=n_jobs)
    distances = model.fit(data)
    distances, indices = distances.kneighbors(data)
    distances = np.sort(distances, axis=0)
    distances = distances[:, 1]
    point = KneeLocator(distances, distances, curve=curve, direction=direction)

    return point.knee, min_pts
