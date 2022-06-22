

# ucitavanje teksta nad kojim se kreiraju ngrami
# prosledjuje se putanja do teksta
def load_data(path):
    f = open(path, "r", encoding="utf8")
    if f.mode != "r":
        return ""
    data = f.read()
    return data


# cuvanje ngrama i verovatnoca pojavljivanja
# prosledjuje se putanja gde se cuva i verovatnoce pojavljivanja za svaki ngram
def save_data(path, prob):
    f = open(path, "w", encoding="utf8")
    if f.mode != "w":
        return
    for ngram in prob:
        f.write('ngram: ' + str(ngram[0]) + ' ')
        f.write('==> probability: %.20f' % ngram[1])
        f.write('\n')
