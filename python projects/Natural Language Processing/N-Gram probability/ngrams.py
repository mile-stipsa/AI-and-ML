import re


# vrsi se preprocesiranje teksta, odnosno uklanjaju se znakovi interpukcije, specijalni karakteri, i izdvajanje tokena
# prosledjuje se ucitan tekst
def tokenize_data(data):
    data_new = data.lower()
    data_new = re.sub('\n', ' ', data_new)
    data_new = re.sub('\W+', ' ', data_new)

    tokens = []
    for token in data_new.split(" "):
        if token != "":
            tokens.append(token)
    return tokens, data_new


# funkcija koja vrsi kreiranje ngrama
# prosledjuju se izdvojeni tokeni i duzina ngrama
def create_ngrams(tokens, n):
    ngrams = list([tokens[i:i+n] for i in range(len(tokens)-n)])
    return ngrams


# funkcija koja racuna verovatnocu pojavljivanja reci
# prosledjuju se rec i preprocesirani tekst
def unigram_probability(word, data):
    word_count = len(re.findall(word, data))
    return word_count/len(data)


# funkcija koja racuna verovatnocu za bigram
# prosledjuju se rec1 rec2, kao i procesirani tekst
def bigram_probability(word1, word2, data):
    word1_count = len(re.findall(word1, data))
    counts = len(re.findall(word1 + " " + word2, data))
    return counts/word1_count


# funkcija koja racuna verovatnocu za trigram
# prosledjuju se rec1 rec2 rec3, kao i procesirani tekst
def trigram_probability(word1, word2, word3, data):
    count1 = len(re.findall(word1 + " " + word2, data))
    count2 = len(re.findall(word1 + " " + word2 + " " + word3, data))
    return count2/count1


# funkcija koja racuna verovatnocu pojavljivanja ukoliko je k=1
# prosledjuje se ngram za kog se racuna verovatnoca i procesirani tekst
def ngram_probability_k1(ngram, data):
    prob = unigram_probability(ngram[0], data)
    for i in range(1, len(ngram)):
        prob = prob * bigram_probability(ngram[i - 1], ngram[i], data)

    return prob


# funkcija koja racuna verovatnocu pojavljivanja ngrama ukoliko je k=2
# prosledjuje se ngram za kog se racuna verovatnoca i procesirani tekst
def ngram_probability_k2(ngram, data):
    prob = unigram_probability(ngram[0], data)
    prob = prob * bigram_probability(ngram[0], ngram[1], data)
    for i in range(2, len(ngram)):
        prob = prob * trigram_probability(ngram[i - 2], ngram[i - 1], ngram[i], data)

    return prob


# funkcija koja racuna verovatnocu pojavljivanja svakog ngrama ukoliko je k=1
# prosledjuje se ngrami i procesirani tekst
def probability_k1(ngrams, data):
    probs = []
    for ngram in ngrams:
        ngram_proba = ngram_probability_k1(ngram, data)
        probs.append([ngram, ngram_proba])
    return probs


# funkcija koja racuna verovatnocu pojavljivanja svakog ngrama ukoliko je k=2
# prosledjuje se ngrami i procesirani tekst
def probability_k2(ngrams, data):
    probs = []
    for ngram in ngrams:
        ngram_proba = ngram_probability_k2(ngram, data)
        probs.append([ngram, ngram_proba])
    return probs
