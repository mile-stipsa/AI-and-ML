from settings import *


# funkcija koja vrsi podelu i promenu dimenzija podataka
# kao parametar se prosledjuju podaci
# kao povratne vrednosti funkcija vraca normalne i anomalicne podatke u vidu pandas okvira i numpy niza
def split_data(data):
    normal_data = data[data.target == str(CLASS_NORMAL)].drop(labels='target', axis=1)
    anomaly_data = data[data.target != str(CLASS_NORMAL)].drop(labels='target', axis=1)

    normal_data_np = normal_data.values.reshape(normal_data.shape[0], 1, normal_data.shape[1])
    anomaly_data_np = anomaly_data.values.reshape(anomaly_data.shape[0], 1, anomaly_data.shape[1])

    return normal_data_np, anomaly_data_np, normal_data, anomaly_data

