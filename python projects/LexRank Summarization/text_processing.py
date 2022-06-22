import string
from nltk.corpus import stopwords
from nltk.tokenize import sent_tokenize, word_tokenize
from nltk.stem import PorterStemmer


# funkcija koja vrsi razdvajanje teksta na recenice
# kao parametri se prosledjuje tekst i jezik na kom je pisan taj tekst
# vraca listu izdvojenih recenica
def sentence_tokenize(text, language='english'):
    tokenized_text = []  # lista gde ce se cuvati recenice
    sentences = sent_tokenize(text, language)  # izdvajanje recenica koriscenjem funkcije iz nltk biblioteke
    for sentence in sentences:
        tokenized_text.append(sentence.lower())  # konvertovanje sva slova u mala, za svaku recenicu
    return tokenized_text


# funkcija koja vrsi tokenizaciju recenica
# kao parametri se prosledjuju recenice i jezik na kome su recenice pisane
# vraca listu reci iz svake recenice (listu listi)
def tokenize_text(sentences, language='english'):
    tokenized_text = []  # lista gde se cuvaju reci
    for sentence in sentences:
        tokenized_text.append(word_tokenize(sentence, language))  # u okviru svake recenice se vrsi izdvajanje reci koriscenjem nltk funkcije
    return tokenized_text


# funkcija koja eliminise stop reci i uklanja znakove interpunkcije
# kao parametri se prosledjuju reci i jezik na kome su te reci pisane
# vraca listu filtriranig reci iz svake recenice (listu listi)
def eliminate_stop_words(sentences, language='english'):
    stop_words = stopwords.words(language)  # uzimanje stop reci iz nltk biblioteke
    filtered_sentences = []  # lista gde se cuvaju filtrirane reci
    for sentence in sentences:
        filtered_sentences.append(  # za svaku rec se proverava da li je u listi sa stop recima i ako nije uklanjaju se znakovi interpukcije i ta rec se dodaje u listu
            [word.translate(str.maketrans('', '', string.punctuation)) for word in sentence if not word in stop_words])
    return filtered_sentences


# funkcija koja vrsi stemovanje reci
# kao parametri se prosledjuju reci
# vraca listu stemova svake recenice (listu listi)
def words_stemmer(sentences):
    stemmed_sentences = []  # lisa gde se cuvaju stemovane reci
    ps = PorterStemmer()  # inicijalizacija porterovog stemera
    for sentence in sentences:
        stemmed_sentences.append(" ".join([ps.stem(word) for word in sentence]))  # cuva se stem svake reci
    return stemmed_sentences


# funkcija koja vrsi formatiranje stemova u zeljeni oblik
# kao parametri se prosledjuju stemovi reci
# vraca sve stemove u okviru jedne liste (listu)
def preprocess_sentences(sentences):
    prep = []
    for sentence in sentences:
        for words in sentence:
            prep.append(words)
    return prep


# funkcija koja vrsi preformatiranje recenice
# kao parametar se prosledjuju izdvojene reci
# vraca listu stringova
def real_sentences(sentences):
    real = []
    for sentence in sentences:
        real.append(" ".join([word for word in sentence]))
    return real
