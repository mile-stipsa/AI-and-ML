import seaborn as sns
import matplotlib.pyplot as plt
from settings import *
import pandas as pd
import tensorflow as tf
import numpy as np
from metrics import confusion_matrix
from load import make_directory, create_data


# funkcija koja vrsi vizuelizaciju distribucije klasa
# kao parametar se prosledjuje klasni atribut
def visualize_class_distribution(data):
    plt.clf()
    sns.set_style()
    ax = sns.countplot(data)
    ax.set_xticklabels(CLASS_NAMES)
    plt.savefig('class_distribution.png')


# funkcija vrsi prikaz sablona klase
# kao parametri se prosledjuju podaci, ime klase, figura gde ce se crtati i broj koraka
def plot_time_series_class(data, class_name, ax, n_steps=10):
    time_series_df = pd.DataFrame(data)  # podaci se ucitavaju u vidu pandas okvira

    smooth_path = time_series_df.rolling(n_steps).mean()  # odredjuje se srednja vrednost podataka uz pomoc klizajuceg prozora
    path_deviation = 2 * time_series_df.rolling(n_steps).std()  # odredjuje se standardna devijacija uz pomoc klizajuceg prozora

    under_line = (smooth_path - path_deviation)[0]  # odredjue se donja granica putanje
    over_line = (smooth_path + path_deviation)[0]  # odredjuje se gornja granica putanje

    ax.plot(smooth_path, linewidth=2)
    ax.fill_between(path_deviation.index, under_line, over_line, alpha=.125)
    ax.set_title(class_name)


# funkcija koja vrsi prikaz sablona klasa
# kao parametar se prosledjuju podaci
def visualize_class_pattern(data):
    plt.clf()
    classes = data.target.unique()
    fig, axs = plt.subplots(nrows=len(classes) // 3 + 1, ncols=3, sharey=True, figsize=(14, 8))  # odredjue se koliko ce imati figurica za crtanje

    for i, cls in enumerate(classes):  # za svaku klasu se vrsi vizuelizacija sablona
        ax = axs.flat[i]
        data_numpy = data[data.target == cls].drop(labels='target', axis=1).mean(axis=0).to_numpy()
        plot_time_series_class(data_numpy, CLASS_NAMES[i], ax)

    fig.delaxes(axs.flat[-1])
    fig.tight_layout()
    plt.savefig('class_patterns.png')


# funkcija koja vrsi vizuelicaju trening gubitaka
# kao parametri se prosledjuje istorija obucavanja modela, putanja gde ce se cuvati figura i funkcija gubitka koja se koristi
def visualize_training_losses(history, path, loss='mae'):
    plt.clf()
    fig, ax = plt.subplots()
    ax.plot(history['loss'], 'b', label='Train loss', linewidth=2)
    ax.plot(history['val_loss'], 'r', label='Validation loss', linewidth=2)
    ax.set_title('Model loss')
    ax.set_ylabel(loss)
    ax.set_xlabel('Epoch')
    plt.legend()
    plt.savefig(path + 'training_loss.png')


# funkcija koja vrsi vizuelizaciju distribucije gubitaka
# kao parametri se prosledjuju originalni podaci, rekonstruisani podaci, funkcija gubitaka, tip podataka, da li se vrsi vizuelizacija ili ne
# funkcija vraca distribuciju gubitaka kao pandas okvir
def visualize_loss_distribution(data, prediction, path, loss, type_of='normal', visualise=False):
    plt.clf()
    scored = pd.DataFrame(index=data.index)
    if loss == 'mae':
        scored[loss] = tf.keras.losses.MAE(data, prediction)
    else:
        scored[loss] = tf.keras.losses.MSE(data, prediction)

    if visualise:
        plt.figure(figsize=(16, 9), dpi=100)
        plt.title("Loss distribution", fontsize=16)
        sns.distplot(scored[loss], bins=50, kde=True, color='Blue')
        plt.savefig(path + type_of + '_loss_distribution.png')
    return scored


# funkcija koja vrsi vizuelizaciju rekonstruisanih vrednosti
# kao parametri se prosledjuju originalni podaci, rekonstruisani podaci, gubitak, naziv i putanja gde se cuva vizuelizacija
def plot_prediction(data, pred, i, score, title, path):
    plt.clf()
    plt.plot(data, label='true')
    plt.plot(pred, label='reconstructed')
    plt.title(f'{title} (loss: {np.around(score, 2)})')
    plt.legend()
    plt.savefig(path + str(i) + '.png')


# funkcija koja vrsi predikciju rekonstruisanih vrednosti klasa
# kao parametri se prosledjuju originalni podaci, rekonstruisani podaci, vrednosti gubitaka, putanja gde se cuva vizuelizacija, i funkcija gubitaka
def visualize_predictions(data, pred, score, path, loss='mae'):
    for i, data in enumerate(data.values):
        if i > PREDICTION:
            break
        plot_prediction(data, pred.values[i], i, score[loss].values[i], str(i), path)


# funkcija koja vrsi vizuelizaciju matrice konfuzije
# kao parametri se prosledjuju ime modela, naziv optimizatora, funkcija gubitaka, i vrednosti koje matrice konfuzije
def visualize_matrix(model_name, optimizer, loss, tn, fp, fn, tp):
    plt.clf()
    matrix = confusion_matrix(tn, fp, fn, tp)
    sns.heatmap(matrix, annot=True, fmt='')
    plt.title(model_name + '(' + optimizer + ')')
    path = 'models/' + model_name + '/' + loss + '/' + optimizer + '/'
    make_directory(path)
    plt.savefig(path + 'confusion_matrix.png')


# funkcija koja vrsi vizuelizaciju anomalija
# kao parametri se prosledjuju originalni podaci, mesta gde je detekovana anomalija, putanja gde ce se cuvati vizuelizacija i redni broj podatka
def plot_anomaly(data, anomalies, path, i):
    plt.clf()
    plt.plot(data.index, data.value, label='measured values')

    sns.scatterplot(
        data=anomalies.value,
        color=sns.color_palette()[3],
        s=52,
        label='anomaly'
    )
    plt.gca().axes.get_yaxis().set_visible(False)
    plt.gca().axes.get_xaxis().set_visible(False)
    plt.title(str(i))
    plt.savefig(path + str(i))


# funkcija koja vrsi vizuelizaciju svih anomalija
# kao parametri se prosledjuju nazivi kolona, originalni podaci, predvidjene vrednosti, prag gubitaka, naziv modela, naziv optimizatora, tip podataka i funkcija gubitaka
def visualize_anomaly(columns, data, predicted, threshold, model, optimizer, type_of_data, loss='mae'):
    for i, d in enumerate(data):
        if i < PREDICTION:
            df, anomalies = create_data(columns, d, predicted[i], threshold, loss) # funkcija koja vrsi kreiranje pandas okvira sa detektovanim anomalijama
            path = 'models/' + model + '/' + loss + '/' + optimizer + '/' + '/detected_anomalies/' + type_of_data + '/'
            make_directory(path)
            plot_anomaly(df, anomalies, path, i)
