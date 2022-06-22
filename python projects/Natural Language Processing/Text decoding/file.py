import re


# ucitavanje teksta koji se desifruje, prosledjuje se putanja do teksta
def load_data(path):
    f = open(path, "r", encoding="utf8")
    if f.mode != "r":
        return ""
    data = f.read()
    f.close()
    return data


# cuvanje desifrovanog teksta, prosledjuje se putanja gde se cuva i podaci koji se cuvaju
def save_data(path, data):
    f = open(path, "w", encoding="utf8")
    if f.mode != "w":
        return
    f.write(data)
    f.close()


# ucitavanje frekvenicja pojavljivanja slova, prosledjuje se putanja do fajla gde se nalaze frekvencije
# ucitavaju se podaci, uklanjaju se blanko znaci i zatim se u okviru recnika cuvaju podaci
# cuva se u formatu frequencies['slovo'] = frekvencija za to slovo, i takav recnik se vraca korisniku
def load_frequencies(path):
    f = open(path, "r", encoding="utf8")
    if f.mode != "r":
        return ""
    data = f.read()
    frequencies = {}
    data = re.sub(" ", '', data)
    letters = data.splitlines()
    for letter in letters:
        fr = letter.split('-')
        frequencies[fr[0]] = float(fr[1])

    f.close()
    return frequencies
