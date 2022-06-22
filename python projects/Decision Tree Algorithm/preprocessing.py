import numpy as np
import pandas as pd
from sklearn.feature_selection import SelectKBest
from sklearn.feature_selection import f_classif


def preprocess_data(data, n):
    df = pd.read_csv(data + '.csv')

    df = df.replace('?', -1)
    labels = df['class']
    df = df.drop('class', axis=1)
    cols = df.columns

    test = SelectKBest(score_func=f_classif, k=n)
    fit = test.fit(df, labels)
    np.set_printoptions(precision=3)
    br = fit.get_support(indices=True)
    col = []
    for i in range(len(cols)):
        if i not in br:
            col.append(cols[i])
    df_new = df.drop(columns=col, axis=1)
    df_new = df_new.join(labels)

    return df_new
