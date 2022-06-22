from coding.preprocessing.text.preprocessing import *
from coding.visualisation.visualisation import class_distribution

data = preprocess_text('datasets/text/bbc/bbc.csv')

class_distribution(data, 'type', 'bbc')
