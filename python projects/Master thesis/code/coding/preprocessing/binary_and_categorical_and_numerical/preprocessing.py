from sklearn.preprocessing import StandardScaler
from sklearn.decomposition import PCA
from Categorical_similarity_measures import ordinal_encode
from imblearn.combine import SMOTETomek
from imblearn.under_sampling import RandomUnderSampler
from sklearn.preprocessing import LabelEncoder
import pandas as pd


def scale_data(data):
    scaler = StandardScaler()
    scaled_data = scaler.fit_transform(data)
    return scaled_data


def encode_class(labels, columns):
    lab = LabelEncoder().fit_transform(labels)
    lab = pd.DataFrame(data=lab, columns=columns)
    return lab


def encode_data(data):
    encoded_data = ordinal_encode(data)
    return encoded_data


# dodaj jos slucajeva za nedostajuce vrednosti
def missing_values(data, data_type='numerical'):
    if data.isnull().values.any():
        if data_type == 'numerical' or data_type == 'text':
            data.fillna(data.mean(), inplace=True)
        else:
            data.fillna(data.mode().iloc[0], inplace=True)


def remove_columns(data, columns):
    return data.drop(columns=columns, axis=1)


def reduce_dimensionality(data, n_attributes=20):
    pca = PCA(n_components=n_attributes)
    reduced_data = pca.fit_transform(data)
    return reduced_data


def load_data(path, miss_values=None):
    data = pd.read_csv(path, na_values=miss_values)
    return data


def resample_data(data, labels, column_name='Class'):
    oversampler = SMOTETomek()
    x, y = oversampler.fit_resample(data, labels)
    x[column_name] = y
    return x


def downsample_data(data, labels, column_name='Class'):
    oversampler = RandomUnderSampler()
    x, y = oversampler.fit_resample(data, labels)
    x[column_name] = y
    return x
