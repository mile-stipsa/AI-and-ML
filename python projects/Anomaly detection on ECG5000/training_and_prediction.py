from visualisation import *
import settings as s
from load import *
from metrics import *


# funkcija koja vrsi predikciju
# prosledjuje se istrenirani model, podaci u nizu, podaci u pandas okviru, ime modela, naziv optimizatora, funkcija gubitka koja se koristi
# naziv tipa podataka za koji se vrsi predvidjanje, i promenljive koje odredjuju koje ce se vizuelizacije vrsiti
# funkcija vraca broj tacno predvidjenih i broj netacno predvidjenih podataka
def show_results(model, data_np, data, model_name, optimizer, loss, data_type='normal', loss_visualization=True,
                 prediction_visualization=False, anomaly_visualization=False):
    prediction = predict(model, data_np, data)  # predvidjanje rezultata
    threshold = THRESHOLDS[loss][model_name]  # ucitavanje praga gubitka

    path = 'models/' + model_name + '/' + loss + '/' + optimizer + '/'  # putanja gde ce se cuvati vizuelizacije
    make_directory(path)

    scored = visualize_loss_distribution(data, prediction, path, loss, data_type, loss_visualization)  # vracanje distribucije gubitaka i njeno cuvanje

    path = 'models/' + model_name + '/' + loss + '/' + optimizer + '/reconstructed/' + data_type + '/'  # putanja gde ce se cuvati rekonstruisani rad srca
    make_directory(path)

    if prediction_visualization:
        visualize_predictions(data, prediction, scored, path, loss)  # vizuelizacija rekonstruisanog rada srca
    if anomaly_visualization:
        visualize_anomaly(data.columns, data.values, prediction.values, threshold[optimizer], model_name, optimizer,
                          data_type, loss)  # vizuelizacija anomalija

    i = count_correct_detection(scored, data_type, threshold[optimizer], loss)  # broj tacno predvidjenih podataka

    return i, len(scored[loss]) - i


# funkcija koja vrsi rekonstrukciju vrednosti
# kao parametri se prosledjuju istrenirani model, podaci za koje se vrsi rekonstrukcija i podaci sa kojih ce se procitati nazivi kolona (mogle je direktno i imena kolona)
def predict(model, data, train_data):
    prediction = model.predict(data)

    prediction = prediction.reshape(prediction.shape[0], prediction.shape[2])
    prediction = pd.DataFrame(prediction, columns=train_data.columns)
    prediction.index = train_data.index

    return prediction


# funkcija koja vrsi treniranje modela
# kao parametri se prosledjuju model koji se trenira, trening podaci, naziv optimizatora, funkcija gubitka (njen naziv) i naziv modela
def training(model, train_data, optimizer='adam', loss='mae', model_name='simple_autoencoder'):
    if loss == 'mse' and optimizer == 'adagrad':  # vrsi se dodeljivanje koeficijenta ucenja za sgd i adagrad ukoliko je rec o njima
        optimizers = tf.keras.optimizers.Adagrad(s.SGD_ADAGRAD_LEARNING_RATE_MSE)
    elif loss == 'mse' and optimizer == 'sgd':
        optimizers = tf.keras.optimizers.SGD(s.SGD_ADAGRAD_LEARNING_RATE_MSE)
    elif loss == 'mae' and optimizer == 'adagrad':
        optimizers = tf.keras.optimizers.Adagrad(s.SGD_ADAGRAD_LEARNING_RATE_MAE)
    elif loss == 'mae' and optimizer == 'sgd':
        optimizers = tf.keras.optimizers.SGD(s.SGD_ADAGRAD_LEARNING_RATE_MAE)
    else:
        optimizers = optimizer

    model.compile(optimizer=optimizers, loss=loss)  # vrsi se kompajliranje modela

    path = 'models/' + model_name + '/' + loss + '/' + optimizer + '/'  # putanja gde ce se istrenirani model cuvati
    if not os.path.isdir(path):
        os.makedirs(path)

    save_model = tf.keras.callbacks.ModelCheckpoint(path + 'model.h5', monitor='val_loss',
                                                    mode='min', verbose=s.VERBOSE, save_best_only=True)  # promenljiva koja odredjuje na osnovu kojih uslova ce se cuvati najbolje stanje modela
    early_stopping = tf.keras.callbacks.EarlyStopping(monitor='val_loss', mode='min', patience=s.PATIENCE,
                                                      restore_best_weights=True, verbose=s.VERBOSE)  # promenljiva koja odredjuje na osnovu kojih parametara ce doci do ranog zaustavljanja
    reduce_lr = tf.keras.callbacks.ReduceLROnPlateau(monitor='val_loss', mode='min', factor=s.REDUCE_FACTOR,
                                                     patience=int(s.PATIENCE / 3), verbose=s.VERBOSE)  # promenljiva koja odredjuje na osnovu kojih parametara ce doci do smanjenja koeficijenta treniranja
    history = model.fit(train_data, train_data,
                        validation_split=s.VALIDATION_SPLIT,
                        epochs=s.EPOCHS,
                        batch_size=s.BATCH_SIZE,
                        callbacks=[save_model,
                                   early_stopping,
                                   reduce_lr
                                   ],
                        verbose=s.VERBOSE + 1,
                        ) # treniranje modela
    visualize_training_losses(history.history, path, loss)  # vizuelizacija gubitaka prilikom treniranja


