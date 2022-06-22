import clustering as cl
import similarity as sm
import numpy as np


# funkcija koja vrsi racunanje lexRank skora za svaku recenicu za svaki klaster
# kao parametri se prosledjuju stemovane reci, broj klastera, neprocesirane recenice, prag slicnosti, kriterijum za izlazak i maksimalan broj iteracija
# vraca skorove za svaki klaster kao i neprocesirane recenice u okviru svakog klastera
def summarize(sentences, real, clusters_number, similarity_threshold=0.3, stopping_criterion=0.0005,
              max_iterations=1000):
    real_cl, stemmed_cl = cl.clustering_sentences(sentences, real, clusters_number)  # klasterizacija recenica
    page_rank_scores = []  # lista koja cuva lexrank skorove

    for i in range(len(stemmed_cl)):  # za svaki klaster
        cl_score = sm.compute_page_rank_score(stemmed_cl[i], similarity_threshold, stopping_criterion,
                                              max_iterations)  # racuna lexrank skorove
        page_rank_scores.append(cl_score)  # dodaje skorove u listu

    return page_rank_scores, real_cl


# funkcija koja vrsi sortiranje rangova u okviru klastera, odnosno na prvu poziciju se stavlja indeks najviseg ranga
# kao parametri se prosledjuju stemovane reci, broj klastera, neprocesirane recenice, broj recenica za klasterovanje...
# ...prag slicnosti, kriterijum za izlazak i maksimalan broj iteracija
# vraca sortirane indekse po rangu i neprocesirane recenice u okviru svakog klastera
def sort_indexes(sentences, real, clusters_numbers, clustering_sentences, similarity_threshold=0.3,
                 stopping_criterion=0.0005, max_iterations=1000):
    page_rank_scores, real_cl = summarize(sentences[:clustering_sentences], real[:clustering_sentences],  # izracunavanje lexrank skora za svaki klaster
                                          clusters_numbers, similarity_threshold, stopping_criterion, max_iterations)
    sorted_indexes = []  # lista koja cuva sortirane indekse za svaki klaster
    for prs in page_rank_scores:
        sorted_indexes.append(np.argsort(prs))  # sortiranje indeksa klastera

    return sorted_indexes, real_cl


# funkcija koja vrsi prikaz sumiranja klastera
# kao parametri se prosledjuju stemovane reci, broj klastera, neprocesirane recenice, broj recenica za klasterovanje...
# ...prag slicnosti, kriterijum za izlazak i maksimalan broj iteracija
def show_clusters_summary(sentences, real, cluster_numbers, clustering_sentences=500, number_of_sentences=3,
                          similarity_threshold=0.3, stopping_criterion=0.0005, max_iterations=1000):
    sorted_indexes, real_cl = sort_indexes(sentences, real, cluster_numbers, clustering_sentences, similarity_threshold,
                                           stopping_criterion, max_iterations)  # vrsi se sortiranje indeksa u okviru svakog klastera
    for i in range(len(sorted_indexes)):  # za svaki klaster
        print("Cluster " + str(i + 1) + " summary:\n")
        sentence = []
        for j in range(number_of_sentences):  # vraca odredjeni broj recenica sa najvisim rangom
            sentence.append(real_cl[i][sorted_indexes[i][j]])
        print("\n".join(sentence))
        print("\n")

