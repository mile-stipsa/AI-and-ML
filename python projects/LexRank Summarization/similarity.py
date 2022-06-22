from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity
import numpy as np


# funkcija vrsi racunanje tf-idf matrice slicnosti
# kao parametar se prosledjuje lista stemova za svaku recenicu (lista listi)
# vraca tf-idf matricu slicnosti
def compute_tf_idf_matrix(sentences):
    vector = TfidfVectorizer()  # kreira se objekat koji racuna matricu
    tf_idf_matrix = vector.fit_transform(sentences)  # vrsi se racunanje tf-idf matrice
    return tf_idf_matrix


# funkcija vrsi racunanje modifikovane kosinusne slicnosti, odnosno grafa slicnosti
# kao parametri se prosledjuju lista stemova za svaku recenicu (lista listi) i prag slicnosti
# funkcija vraca kosinusnu slicnost i listu stepena povezanosti
def compute_modified_cosine_similarity(sentences, similarity_threshold=0.3):
    tf_idf_matrix = compute_tf_idf_matrix(sentences)  # vrsi racunanje tf-idf matrice slicnosti

    cosine_similarities = np.empty(shape=(tf_idf_matrix.shape[0], tf_idf_matrix.shape[0]))  # kreiranje matrice gde ce se cuvati modifikovana kosinusna slicnost
    degrees = np.zeros(shape=(tf_idf_matrix.shape[0]))  # kreiranje niza gde ce se cuvati stepen povezanosti svakog cvora

    for i, sent1 in enumerate(tf_idf_matrix):  # za svaki element matrice
        for j, sent2 in enumerate(tf_idf_matrix):  # za svaki element matrice
            calculated_cosine_similarity = cosine_similarity(sent1, sent2)  # vrsi se racunanje kosinusne slicnosti dva vektora
            if calculated_cosine_similarity > similarity_threshold:  # ukoliko je slicnost veca od praga
                cosine_similarities[i, j] = calculated_cosine_similarity  # cuva se vrednost na odgovarajucoj poziciji u matrici
                degrees[i] += 1  # povecava se stepen povezanosti
            else:
                cosine_similarities[i, j] = 0  # inace slicnos je 0

    cosine_similarities = cosine_similarities / degrees  # deli kosinusnu slicnost sa stepenom povezanosti
    return cosine_similarities, degrees


# funkija koja vrsi racunanje page rank skora
# kao parametri se prosledjuju lista stemova za svaku recenicu, prag slicnosti, kriterijum za zaustavljanje i maksimalan broj iteracija
# vraca matricu page rank skora
def compute_page_rank_score(sentences, similarity_threshold=0.3, stopping_criterion=0.0005, max_iterations=1000):
    cosine_similarities, degrees = compute_modified_cosine_similarity(sentences, similarity_threshold)  # izracunavanje kosinusne slicnosti
    p_initial = np.ones(shape=len(degrees)) / len(degrees)  # kreiranje vektora
    i = 0
    while True:
        i += 1
        p_update = np.matmul(cosine_similarities.T, p_initial)  # mnozenje matrica
        delta = np.linalg.norm(p_update - p_initial)  # racunanje apsolutne greske
        if delta < stopping_criterion or i >= max_iterations:  # ukoliko je zadovoljen jedan od uslova za izlazak izlazi se
            break
        else:
            p_initial = p_update  # inace se pocetni vektor postaje izracunati
    p_update = p_update / np.max(p_update)  # vrsi se deljenje rezultata sa maksimalnim
    return p_update
