import numpy as np


# funkcija koja vrsi racunanje mera performansi sistema
# kao parametri se prosledjuju pandas okvir gde ce se vrednosti cuvati, naziv optimizatora i vrednosti iz matrice konfuzije
def metrics(dataframe, optimizer, tn, fp, fn, tp):
    accuracy = (tp + tn) / (tp + fp + fn + tn)
    precision = tp / (tp + fp)
    recall = tp / (tp + fn)
    f1 = 2 * (precision * recall) / (precision + recall)

    dataframe.loc[optimizer] = [accuracy, precision, recall, f1]


# funkcija koja vrsi kreiranje matrice konfuzije
# kao parametri prosledjuju se vrednosti koje se upisuju u matricu
# kao povratnu vrednost funkcija vraca kreiranu matricu u vidu numpy niza
def confusion_matrix(tn, fp, fn, tp):
    matrix = np.array([[tn, fp], [fn, tp]])
    return matrix


# funkcija koja broji broj uspesno predvidjenih klasa
# kao parametri se prosledjuju gubici, tip podataka, prag gubitaka i funkcija gubitaka
# kao povratnu vrednost funkcija vraca broj tacno predvidjenih klasa
def count_correct_detection(scored, data_type, threshold, loss):
    i = 0
    for a in scored[loss]:
        if data_type == 'normal':
            if a <= threshold:
                i = i + 1
        else:
            if a > threshold:
                i = i + 1
    return i
