from sklearn.feature_extraction.text import TfidfVectorizer
from gensim import corpora
from gensim import models
import numpy as np


def tfidf_model(data):
    tf = TfidfVectorizer()
    matrix = tf.fit_transform(data['news_stemmed']).toarray()
    return matrix


def lda_model(data, topics, no_below=15, no_above=0.1, passes=5, minimum_probability=0.0, save_model=False,
              save_path=None):
    text = data['news_models']
    dictionary = corpora.Dictionary(text)
    dictionary.filter_extremes(no_below=no_below, no_above=no_above)

    corpus = [dictionary.doc2bow(text) for text in text]
    lda = models.LdaModel(corpus, num_topics=topics, id2word=dictionary, passes=passes)

    if save_model:
        lda.save(save_path + '/lda.model')

    lda_representation = []
    for i in range(len(text)):
        top_topics = lda.get_document_topics(corpus[i], minimum_probability=minimum_probability)
        topic_probability = [top_topics[i][1] for i in range(topics)]
        lda_representation.append(topic_probability)

    return np.array(lda_representation)


def doc2vec_model(data, vector_size=500, n_jobs=12, save_model=False, save_path=None, window=7):
    tagged_documents = data.apply(lambda x: models.doc2vec.TaggedDocument(words=x['news_models'], tags=x.type),
                                  axis=1)

    doc2vec = models.doc2vec.Doc2Vec(documents=tagged_documents, vector_size=vector_size, workers=n_jobs, window=window)
    if save_model:
        doc2vec.save(save_path + '/doc2vec.model')
    representation = data.apply(lambda x: doc2vec.infer_vector(x['news_models']), axis=1)
    doc2vec_representation = []

    for i in range(len(representation)):
        arr = list(representation[i])
        doc2vec_representation.append(arr)

    return np.array(doc2vec_representation)


def hybrid_model(data, topics, no_below=15, no_above=0.1, passes=5, minimum_probability=0.0, vector_size=500, n_jobs=12,
                 save_model=False, save_path_lda=None, save_path_doc2vec=None):
    lda = lda_model(data, topics, no_below, no_above, passes, minimum_probability, save_model,
                    save_path_lda)
    doc2vec = doc2vec_model(data, vector_size, n_jobs, save_model, save_path_doc2vec)
    hybrid = []
    for i in range(len(lda)):
        arr = np.concatenate((lda[i], doc2vec[i]), axis=None)
        hybrid.append(arr)
    return np.array(hybrid)
