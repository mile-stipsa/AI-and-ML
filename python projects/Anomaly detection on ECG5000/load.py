import os
from arff2pandas import a2p
import tensorflow as tf
import pandas as pd
import numpy as np


# funkcija koja ucitava podatke iy arff fajla u pandas okvir
# kao parametar prosledjuje se putanja do fajla
# funkcija vraca pandas okvir sa podacima
def load_data(file_name):
    with open(file_name) as f:
        data = a2p.load(f)
    return data


# funkcija koja vrsi nadovezivanje trening i test podataka i vrsi promenu imena klasnog atributa
# kao parametri prosledjuju se pandas okviri trening i test skupa podataka i ime koje zelimo za klasni atribut
# funkcija pandas okvir sa nadovezanim podacima
def concatenate_data(train_data, test_data, class_column='target'):
    data = train_data.append(test_data)
    # funkcija koja vrsi slucajno rasporedjivanje podataka u pandas okviru, parametar koji se prosledjuje je procenat podataka koji ce se rasporedjivati
    data = data.sample(frac=1.0)
    data = rename_class_column(data, class_column)
    return data


# funkcija koja vrsi promenu imena klasnog atributa
# kao parametri se prosledjuju pandas okvir sa podacima i ime koje zelimo za klasni atribut
# funkcija vraca pandas okvir sa promenjenim nazivom klasnog atributa
def rename_class_column(data, name):
    new_columns = list(data.columns)
    new_columns[-1] = name
    data.columns = new_columns
    return data


# funkcija koja ucitava istrenirane modele u recnik
# kao parametri se prosledjuju naziv optimizatora koji predstavlja kljuc za recnik, naziv modela koji ucitavamo i funkcija gubitka koja se koristi
# funkcija vraca recnik sa ucitanim istreniranim modelima
def load_models(optimizers, model_name, loss):
    models = {}
    for optimizer in optimizers:
        models[optimizer] = tf.keras.models.load_model(
            'models/' + model_name + '/' + loss + '/' + optimizer + '/' '/model.h5')
    return models


# funkcija koja proverava da li postoji zeljeni direktorijum i ako ne postoji pravi isti
# kao parametar se prosledjuje putanja direktorijuma
def make_directory(path):
    if not os.path.isdir(path):
        os.makedirs(path)


# funkcija koja vrsi kreiranje pomocnog pandas okvira za prikaz mesta gde se desila anomalija
# kao parametri se prosledjuju imena kolona, originalni podaci, podaci koje predvidja model, granicna greska i gubitak koji se koristi
# funkcija vraca pandas okvire podataka i pronadjenih anomalija u radu srca
def create_data(columns, data, predicted, threshold, loss):
    df = pd.DataFrame(index=columns)
    df['value'] = data
    if loss == 'mae':
        df['loss'] = np.abs(np.subtract(data, predicted))
    else:
        df['loss'] = np.square(np.subtract(data, predicted))
    df['threshold'] = threshold
    df['anomaly'] = df.loss > df.threshold
    anomalies = df[df.anomaly == True]

    return df, anomalies
