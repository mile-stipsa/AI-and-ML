import text_processing as pp
from sklearn.datasets import load_files
import pandas as pd


# funkcija koja vrsi ucitavanje tekstova
# kao parametar se prosledjuje direktorijum
# vraca stemove reci i stvarne recenice
def load_sentences(directory='bbc'):
    data = load_files(directory, encoding="utf-8", decode_error="replace")  # ucitavanje tekstova
    df = pd.DataFrame(list(zip(data['data'], data['target'])), columns=['text', 'label'])  # preformatiranje tekstova u okviru data frame-a

    sent = []  # lista koja cuva izdvojene recenice
    for sentence in df.text.values:
        sent.append(pp.sentence_tokenize(sentence))  # izdvajanje recenica

    text = []  # lista koja cuva izdvojene rece
    for sentence in sent:
        text.append(pp.tokenize_text(sentence))  # izdvajanje reci
    stop = []  # lista koja cuva reci bez stop reci
    for words in text:
        stop.append(pp.eliminate_stop_words(words))  # izdvajanje stop reci

    stemmed = []  # lista koja cuva stemove reci
    for words in stop:
        stemmed.append(pp.words_stemmer(words))  # stemovanje reci
    prep_stemmed = pp.preprocess_sentences(stemmed)  # preformatiranje liste

    sentences = []  # lista koja cuva stvarne recenice
    for words in text:
        sentences.append(pp.real_sentences(words))  # kreiranje stvarnih recenica
    real_sentences = pp.preprocess_sentences(sentences)  # preformatiranje liste

    return prep_stemmed, real_sentences
