from preprocess import *
from training_and_prediction import *
from visualisation import *

train = load_data(TRAIN_DATA)
test = load_data(TEST_DATA)

data = concatenate_data(train, test)
normal_data_np, anomaly_data_np, normal_data, anomaly_data = split_data(data)

models_all = {}
for loss in LOSSES:
    models_all[loss] = {}
    for model in MODELS:
        models_all[loss][model] = load_models(OPTIMIZERS, model, loss) # ucitavanje istreniranih modela

for loss, models in models_all.items():
    for model_name, optimizers in models.items():  # za sve moguce konfiguracije modela
        dataframe = pd.DataFrame(index=OPTIMIZERS, columns=METRICS)  # pandas okvir gde se cuvaju performanse
        modelings = True

        for optimizer, model in optimizers.items():
            if modelings:  # vizuelizacija modela
                path = 'models/' + model_name + '/'
                tf.keras.utils.plot_model(model, path + 'model.png', True)
                modelings = False

            correct_normal, incorrect_normal = show_results(model, normal_data_np, normal_data, model_name, optimizer, loss,
                                                            DATA_TYPES[0], LOSS_VISUALIZATION, PREDICTION_VISUALIZATION,
                                                            ANOMALY_VISUALIZATION)  # predvidjanje za normalan rad srca
            correct_anomaly, incorrect_anomaly = show_results(model, anomaly_data_np, anomaly_data, model_name, optimizer, loss,
                                                              DATA_TYPES[1], LOSS_VISUALIZATION, PREDICTION_VISUALIZATION,
                                                              ANOMALY_VISUALIZATION)  # predvidjanje za anomalican rad srca
            print(model_name + '(' + optimizer + '): ')
            if CONFUSION_MATRIX_AND_METRICS:  # vizuelizacija matrice konfuzije i cuvanje performansi
                metrics(dataframe, optimizer, correct_anomaly, incorrect_anomaly, incorrect_normal, correct_normal)
                visualize_matrix(model_name, optimizer, loss, correct_anomaly, incorrect_anomaly, incorrect_normal, correct_normal)
            print('\n')
        dataframe.to_csv('models/' + model_name + '/'+loss+'/metrics.csv')
