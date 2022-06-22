from collections import Counter
import numpy as np
import re


# vrsi se preprocesiranje teksta, odnosno uklanjanje znakova interpunkcije, brojeva, specijalnih karaktera (stoji u tekstu zadatka)
# prosledjuje se tekst koji je potrebno preprocesirati
def preprocessing_text(data):
    data_new = re.sub('\n', '', data)
    data_new = re.sub('\W+', '', data_new)
    data_new = re.sub('[0-9]', '', data_new)
    return data_new


# racuna se frekvencija pojavljivanja slova u sifrovanom tekstu
# prosledjuje se preprocesirani tekst
# funkcija Counter vraca broj pojavljivanja svakog slova u tekstu
# frekvencija pojavljivanja se cuva u okviru recnika
# format je frequency['slovo'] = frekvencija pojavljivanja za slovo
def letter_frequency(data):
    count = Counter(data)
    length = len(data)
    keys = count.keys()
    frequency = {}
    for key in keys:
        frequency[key] = float(count[key] / length)
    return frequency


# vrsi preprocesiranje uklanjanje slova iz recnika frekvencija
# iz razloga sto pojedina slova u sifrovanom tektsu ostaju ista kao i u desifrovanom (stoji u tekstu zadatka)
# prosledjuju se frekvence pojavljivanja slova u sifrovanom i desifrovanom tekstu
def preprocessing_key(letters1, letters2):
    letters = letters1.copy()
    for key in letters1.keys():
        if key not in letters2.keys():
            letters.pop(key)

    return letters


# funkcija koja na osnovu frekvence pojavljivanja slova u sifrovanom tekstu pronalazi
# slovo u sifrovanom tekstu koje ima najblizu frekvencu pojavljivanja
# prosledjuje se frekvenca pojavljivanja slova u sifrovanom tekstu i frekvence pokavljivanja slova u desifrovanom
# vraca slovo koje ima najslicniju frekvencu pojavljivanja
def compare(value1, frequencies2):
    temp_value = value1
    for key2, value2 in frequencies2.items():
        diff = abs(value1 - value2)
        if diff <= temp_value:
            temp_value = diff
            temp_key = key2
    return temp_key


# funkcija koja za svako slovo u sifrovanom tekstu pronalazi slovo koje ima najslicniju frekvencu pojavljivanja
# prosledjuju se frekvence pojavljivanja slova u sifrovanom i desifrovanom tekstu
def decode(frequencies1, frequencies2):
    letters = {}
    for key1, value1 in frequencies1.items():
        temp_key = compare(value1, frequencies2)
        letters[key1] = temp_key
    return letters


# funkcija koja vraca indekse gde se svako slovo u sifrovanom tekstu pojavljuje
# prosledjuju se frekvence pojavljivanja slova u sifrovanom tekstu i nepreprocesirani tekst
def indexes(frequencies1, data):
    data_new = np.array(list(data))
    indexed = {}
    for key in frequencies1.values():
        indexed[key] = np.where(data_new == key)

    return indexed


# funkcija koja desifruje sifrovani tekst
# prosledjuju se uparena slova i nepreprocesirani tekst
def replace(letters1, data):
    data_new = list(data)
    index = indexes(letters1, data)
    for key, value in letters1.items():
        for ind in index[key]:
            for i in range(len(ind)):
                data_new[ind[i]] = value

    return ''.join(data_new)
