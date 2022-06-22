import tensorflow as tf


# funkcija koja vrsi kreiranje najjednostavnijeg modela
# kao parametri se prosledjuju podaci, broj skrivenih slojeva i procenat odbacivanja skrivenih slojeva
# kao povratnu vrednost funkcija vraca kreirani model
def simple_autoencoder_model(data, hidden=128, dropout_rate=0.1):
    inputs = tf.keras.Input(shape=(data.shape[1], data.shape[2]))
    L1 = tf.keras.layers.Dense(int(hidden / 4), activation='relu')(inputs)
    L2 = tf.keras.layers.Dropout(dropout_rate)(L1)
    outputs = tf.keras.layers.TimeDistributed(tf.keras.layers.Dense(data.shape[2]))(L2) # omogucava primenu sloja na svaku podatak u okviru vremenske serije
    model = tf.keras.Model(inputs=inputs, outputs=outputs)
    return model


# funkcija koja vrsi kreiranje potpuno povezanog modela
# kao parametri se prosledjuju podaci, broj skrivenih slojeva i procenat odbacivanja skrivenih slojeva
# kao povratnu vrednost funkcija vraca kreirani model
def deep_autoencoder_model(data, hidden=128, dropout_rate=0.1):
    inputs = tf.keras.Input(shape=(data.shape[1], data.shape[2]))
    L1 = tf.keras.layers.Dense(int(hidden / 2), activation='relu')(inputs)
    L2 = tf.keras.layers.Dense(int(hidden / 4), activation='relu')(L1)
    L3 = tf.keras.layers.Dense(int(hidden / 8), activation='relu')(L2)
    L4 = tf.keras.layers.Dense(int(hidden / 16), activation='relu')(L3)
    L5 = tf.keras.layers.Dense(int(hidden / 32), activation='relu')(L4)
    L6 = tf.keras.layers.Dropout(dropout_rate)(L5)
    L7 = tf.keras.layers.Dense(int(hidden / 16), activation='relu')(L6)
    L8 = tf.keras.layers.Dense(int(hidden / 8), activation='relu')(L7)
    L9 = tf.keras.layers.Dense(int(hidden / 4), activation='relu')(L8)
    L10 = tf.keras.layers.Dense(int(hidden / 2), activation='relu')(L9)
    outputs = tf.keras.layers.TimeDistributed(tf.keras.layers.Dense(data.shape[2]))(L10)
    model = tf.keras.Model(inputs=inputs, outputs=outputs)
    return model


# funkcija koja vrsi kreiranje LSTM modela
# kao parametri se prosledjuju podaci, broj skrivenih slojeva i procenat odbacivanja skrivenih slojeva
# kao povratnu vrednost funkcija vraca kreirani model
def LSTM_autoencoder_model(data, hidden=128, dropout_rate=0.1):
    inputs = tf.keras.Input(shape=(data.shape[1], data.shape[2]))
    L1 = tf.keras.layers.LSTM(hidden, return_sequences=True)(inputs)
    L2 = tf.keras.layers.LSTM(int(hidden / 2), activation='relu', return_sequences=True)(L1)
    L3 = tf.keras.layers.LSTM(int(hidden / 4), activation='relu', return_sequences=True)(L2)
    L4 = tf.keras.layers.LSTM(int(hidden / 8), activation='relu', return_sequences=False)(L3)
    L5 = tf.keras.layers.RepeatVector(data.shape[1])(L4)
    L6 = tf.keras.layers.Dropout(dropout_rate)(L5)
    L7 = tf.keras.layers.LSTM(int(hidden / 8), activation='relu', return_sequences=True)(L6)
    L8 = tf.keras.layers.LSTM(int(hidden / 4), activation='relu', return_sequences=True)(L7)
    L9 = tf.keras.layers.LSTM(int(hidden / 2), activation='relu', return_sequences=True)(L8)
    L10 = tf.keras.layers.LSTM(hidden, activation='relu', return_sequences=True)(L9)
    output = tf.keras.layers.TimeDistributed(tf.keras.layers.Dense(data.shape[2]))(L10)
    model = tf.keras.Model(inputs=inputs, outputs=output)
    return model


# funkcija koja vrsi kreiranje GRU modela
# kao parametri se prosledjuju podaci, broj skrivenih slojeva i procenat odbacivanja skrivenih slojeva
# kao povratnu vrednost funkcija vraca kreirani model
def GRU_autoencoder_model(data, hidden=128, dropout_rate=0.1):
    inputs = tf.keras.Input(shape=(data.shape[1], data.shape[2]))
    L1 = tf.keras.layers.GRU(hidden, activation='relu', return_sequences=True)(inputs)
    L2 = tf.keras.layers.GRU(int(hidden / 2), activation='relu', return_sequences=True)(L1)
    L3 = tf.keras.layers.GRU(int(hidden / 4), activation='relu', return_sequences=True)(L2)
    L4 = tf.keras.layers.GRU(int(hidden / 8), activation='relu', return_sequences=False)(L3)
    L5 = tf.keras.layers.RepeatVector(data.shape[1])(L4)
    L6 = tf.keras.layers.Dropout(dropout_rate)(L5)
    L7 = tf.keras.layers.GRU(int(hidden / 8), activation='relu', return_sequences=True)(L6)
    L8 = tf.keras.layers.GRU(int(hidden / 4), activation='relu', return_sequences=True)(L7)
    L9 = tf.keras.layers.GRU(int(hidden / 2), activation='relu', return_sequences=True)(L8)
    L10 = tf.keras.layers.GRU(hidden, activation='relu', return_sequences=True)(L9)
    output = tf.keras.layers.TimeDistributed(tf.keras.layers.Dense(data.shape[2]))(L10)
    model = tf.keras.Model(inputs=inputs, outputs=output)
    return model


# funkcija koja vrsi kreiranje konvolucionog modela
# kao parametri se prosledjuju podaci, velicina kernela, broj filtera i procenat odbacivanja skrivenih slojeva
# # kao povratnu vrednost funkcija vraca kreirani model
def convolution_autoencoder_model(data, kernel_size=1, filters=128, dropout_rate=0.1):
    inputs = tf.keras.Input(shape=(data.shape[1], data.shape[2]))
    L1 = tf.keras.layers.Conv1D(filters=filters, kernel_size=kernel_size)(inputs)  # primena konvolucionog jednodimenzionog filtera
    L2 = tf.keras.layers.Conv1D(filters=int(filters / 2), kernel_size=kernel_size)(L1)
    L3 = tf.keras.layers.Conv1D(filters=int(filters / 4), kernel_size=kernel_size)(L2)
    L4 = tf.keras.layers.Conv1D(filters=int(filters / 8), kernel_size=kernel_size)(L3)
    L5 = tf.keras.layers.Dropout(dropout_rate)(L4)
    L6 = tf.keras.layers.Conv1DTranspose(filters=int(filters / 8), kernel_size=kernel_size)(L5)  # primena dekonvolucionog jednodimenzionog filtera
    L7 = tf.keras.layers.Conv1DTranspose(filters=int(filters / 4), kernel_size=kernel_size)(L6)
    L8 = tf.keras.layers.Conv1DTranspose(filters=int(filters / 2), kernel_size=kernel_size)(L7)
    L9 = tf.keras.layers.Conv1DTranspose(filters=filters, kernel_size=kernel_size)(L8)
    output = tf.keras.layers.TimeDistributed(tf.keras.layers.Dense(data.shape[2]))(L9)
    model = tf.keras.Model(inputs=inputs, outputs=output)
    return model
