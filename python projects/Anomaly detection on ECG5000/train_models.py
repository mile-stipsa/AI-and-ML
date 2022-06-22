from preprocess import *
from training_and_prediction import *
from autoencoder_models import *
from settings import *

train = load_data(TRAIN_DATA)
test = load_data(TEST_DATA)

data = concatenate_data(train, test)
normal_data_np, anomaly_data_np, normal_data, anomaly_data = split_data(data)

for loss in LOSSES:
    for optimizer in OPTIMIZERS:  # za svaku konfiguraciju vrsi se obucavanje modela nad podacima koji predstavljaju normalan rad srca
        model1 = simple_autoencoder_model(normal_data_np, HIDDEN_LAYERS, DROPOUT_RATE)
        training(model1, normal_data_np, optimizer, loss, 'simple_autoencoder')

        model2 = deep_autoencoder_model(normal_data_np, HIDDEN_LAYERS, DROPOUT_RATE)
        training(model2, normal_data_np, optimizer, loss, 'deep_autoencoder')

        model3 = LSTM_autoencoder_model(normal_data_np, HIDDEN_LAYERS, DROPOUT_RATE)
        training(model3, normal_data_np, optimizer, loss, 'LSTM_autoencoder')

        model4 = GRU_autoencoder_model(normal_data_np, HIDDEN_LAYERS, DROPOUT_RATE)
        training(model4, normal_data_np, optimizer, loss, 'GRU_autoencoder')

        model5 = convolution_autoencoder_model(normal_data_np, KERNEL_SIZE, HIDDEN_LAYERS, DROPOUT_RATE)
        training(model5, normal_data_np, optimizer, loss, 'convolution_autoencoder')
