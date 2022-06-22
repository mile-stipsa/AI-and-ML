import letter_frequency as lf
import file as f


data = f.load_data('2 (sifrovano).txt')  # ucitavanje teksta
data_new = lf.preprocessing_text(data)  # preprocesiranje teksta
frequencies2 = f.load_frequencies("2 (verovatnoce).txt")  # ucitavanje frekvence pojavljivanja slova u desifrovanom tekstu

frequencies1 = lf.letter_frequency(data_new)  # racunanje frekvence pojavljivanja slova nad preprocesiranim podacima
frequencies1 = lf.preprocessing_key(frequencies1, frequencies2)  # uklanjanje slova za koja ne postoji frekvenca pojavljivanja u desifrovanom tekstu

key1 = lf.decode(frequencies1, frequencies2)  # uparivanje slova
data_replaced = lf.replace(key1, data)  # zamena slova

f.save_data('2 (desifrovano).txt', data_replaced)  # cuvanje desifrovanog teksta
