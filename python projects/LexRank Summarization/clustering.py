import similarity as sm
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt


# funkcija koja graficki predstavlja distorziju
# kao parametar se prosledjuje lista zabelezenih distorzija
def plot_elbow(data):
    plt.figure()
    plt.plot(data, 'bx-')
    plt.xlabel('k')
    plt.ylabel('Distortion')
    plt.title('The Elbow Method showing the optimal k')
    plt.show()


# funkcija koja odredjuje optimalan broj klastera, odnosno graficki predstavlja smanjenje distorzije s povecanjem broja klastera
# kao parametri se prosledjuju lista stemova u recenicama i broj klastera
def elbow_method(sentences, clusters_numbers):
    distortions = []  # lista koja cuva zabelezene distorzije
    matrix = sm.compute_tf_idf_matrix(sentences)  # funkcija koja kreira tf-idf matricu slicnosti
    K = range(1, clusters_numbers)
    for k in K:
        kmeansModel = KMeans(n_clusters=k)  # kreiranje KMeans modela
        kmeansModel.fit(matrix)  # fitovanje tf-idf matrice
        distortions.append(kmeansModel.inertia_)  # dodavanje distorzije u listu
    plot_elbow(distortions)  # graficki prikaz rezultata


# funkcija koja vrsi klasterizaciju recenica
# kao parametri se prosledjuju lista stemova u recenicama i broj klastera
# vraca broj klastera za svaku recenicu
def text_clustering(sentences, clusters_number):
    matrix = sm.compute_tf_idf_matrix(sentences)  # kreiranje tf-idf matrice slicnosti
    model = KMeans(n_clusters=clusters_number, init='k-means++', max_iter=100, n_init=1)  # kreiranje KMeans modela
    model.fit(matrix)  # fitovanje tf-idf matrice

    prediction = model.predict(matrix)  # klasterizacija recenica, vraca broje klastera kome svaka recenica pripada
    return prediction


# funkcija koja vrsi klasterovanje recenica
# kao parametri se prosledjuju lista stemova u recenicama, nepreprocesirane recenice i broj klastera
# vraca listu nepreprocesiranih recenica za svaki klaster kao i listu stemova za svaki klaster
def clustering_sentences(sentences, real, clusters_number):
    real_clustered = []  # lista koja cuva nepreprocesirane recenice za svaki klaster
    stemmed_clustered = []  # lista koja cuva stemova recenica za svaki klaster

    # za svaki klaster se kreira lista
    for i in range(clusters_number):
        real_clustered.append([])
        stemmed_clustered.append([])

    prediction = text_clustering(sentences, clusters_number)  # vrsi se klasterovanje recenica

    # vrsi se dodavanje nepreprocesiranih recenica i stemova u svaki klaster
    for i in range(len(prediction)):
        real_clustered[prediction[i]].append(real[i])
        stemmed_clustered[prediction[i]].append(sentences[i])

    return real_clustered, stemmed_clustered
