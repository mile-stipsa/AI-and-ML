import numpy as np
from sklearn.model_selection import train_test_split
# from sklearn.preprocessing import StandardScaler

import preprocessing as pp
import algorithms as alg

dg = pp.preprocess_data('data1', 5)
# Izvlacenje klasnog atributa
labels = np.array(dg['class'])
dg = dg.drop('class', axis=1)
df = np.array(dg)

# if False:
# stdsc = StandardScaler()
# df = stdsc.fit_transform(df)

# podela na trening itest skup
train, test, train_labels, test_labels = train_test_split(df, labels, stratify=labels, test_size=0.33, random_state=0)

col = dg.columns.values

alg.CART(train, train_labels, test, test_labels, col)
alg.ID3(train, train_labels, test, test_labels, col)
