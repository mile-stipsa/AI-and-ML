CLASS_NORMAL = 1  # klasa koja oznacava normalan rad srca
CLASS_NAMES = ['Normal', 'R on T', 'PVC', 'SP', 'UB']  # imena klasa
DATA_TYPES = ['normal', 'anomaly']  # tipovi rada srca

TRAIN_DATA = 'dataset/ECG5000_TRAIN.arff'  # putanja do trening skupa
TEST_DATA = 'dataset/ECG5000_TEST.arff'  # putanja do test skupa

EPOCHS = 1000  # ukupan broj epoha
BATCH_SIZE = 64  # velicina batch-a
VALIDATION_SPLIT = 0.25  # procenat podataka koji ce se koristiti za validaciju prilikom testiranja
HIDDEN_LAYERS = 128  # maksimalni broj skrivenih slojeva
DROPOUT_RATE = 0.1  # procenat odbacivanja neurona
KERNEL_SIZE = 1  # velicina kernela
LOSSES = ['mae', 'mse']  # funkcije gubitaka koje se koriste

SGD_ADAGRAD_LEARNING_RATE_MAE = 0.1  # koeficijent ucenja za sgd i adagrad optimizator kod srednje apsolutne greske
SGD_ADAGRAD_LEARNING_RATE_MSE = 0.01  # koeficijent ucenja za sgd i adagrad optimizator kod srednje kvadratne greske

PATIENCE = 30  # maksimalan broj epoha koje se broje prilikom ranog zaustavljanja ili smanjenja koeficijenta
REDUCE_FACTOR = 0.1  # procenat smanjenja koeficijenta ucenja
VERBOSE = 1  # opcija stampanja napretka kod obucavanja modela

RANDOM_SEED = 42  # koeficijent slucajnosti
THRESHOLDS = {  # pragovi gresaka koje se koriste za otkrivanje anomalija rada srca
    'mae': {'simple_autoencoder': {'adam': 0.17, 'nadam': 0.17, 'adagrad': 0.2, 'rmsprop': 0.17, 'sgd': 0.28},
            'deep_autoencoder': {'adam': 0.33, 'nadam': 0.33, 'adagrad': 0.37, 'rmsprop': 0.38, 'sgd': 0.48},
            'LSTM_autoencoder': {'adam': 0.33, 'nadam': 0.33, 'adagrad': 0.5, 'rmsprop': 0.33, 'sgd': 0.5},
            'GRU_autoencoder': {'adam': 0.3, 'nadam': 0.3, 'adagrad': 0.5, 'rmsprop': 0.3, 'sgd': 0.5},
            'convolution_autoencoder': {'adam': 0.13, 'nadam': 0.15, 'adagrad': 0.17, 'rmsprop': 0.16, 'sgd': 0.21},
            },
    'mse': {'simple_autoencoder': {'adam': 0.15, 'nadam': 0.17, 'adagrad': 0.25, 'rmsprop': 0.16, 'sgd': 0.28},
            'deep_autoencoder': {'adam': 0.35, 'nadam': 0.35, 'adagrad': 0.44, 'rmsprop': 0.35, 'sgd': 0.44},
            'LSTM_autoencoder': {'adam': 0.37, 'nadam': 0.3, 'adagrad': 0.5, 'rmsprop': 0.3, 'sgd': 0.5},
            'GRU_autoencoder': {'adam': 0.25, 'nadam': 0.3, 'adagrad': 0.55, 'rmsprop': 0.25, 'sgd': 0.5},
            'convolution_autoencoder': {'adam': 0.13, 'nadam': 0.15, 'adagrad': 0.2, 'rmsprop': 0.15, 'sgd': 0.21},
            }
}

OPTIMIZERS = ['adam', 'nadam', 'adagrad', 'rmsprop', 'sgd']  # optimizatori koji se koriste prilikom eksperimentisanja
MODELS = ['simple_autoencoder', 'deep_autoencoder', 'LSTM_autoencoder', 'GRU_autoencoder', 'convolution_autoencoder']  # nazivi modela koji se koriste u eksperimentisanju
METRICS = ['accuracy', 'precision', 'recall', 'f1']  # mere koje se koriste za poredjenje performansi sistema
LOSS_VISUALIZATION = True  # promenljiva koja odredjuje da li ce se vizuelizovati gubici
PREDICTION_VISUALIZATION = True  # promenljiva koja odredjuje da li ce se vizuelizovati predvidjanja modela
ANOMALY_VISUALIZATION = True  # promenljiva koja odredjuje da li ce se vizuelizovati detektovane anomalije
CONFUSION_MATRIX_AND_METRICS = True  # promenljiva koja odredjuje da li ce se vizuelizovati matrica konfuzije i da li ce se cuvati mere

PREDICTION = 50  # promenljiva koja odredjuje za koliko podataka ce se vrsiti izabrane vizuelizacije
