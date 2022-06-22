from scipy.spatial import distance

distances = {
    'yule': distance.yule,
    'sokalsneath': distance.sokalsneath,
    'sokalmichener': distance.sokalmichener,
    'russellrao': distance.russellrao,
    'hamming': distance.hamming,
    'rogerstanimoto': distance.rogerstanimoto,
    'dice': distance.dice,
    'jaccard': distance.jaccard,
    'kulsinski': distance.kulsinski
}
