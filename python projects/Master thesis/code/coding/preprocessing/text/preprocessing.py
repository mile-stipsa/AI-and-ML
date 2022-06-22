import pandas as pd
import os
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer


def create_csv(data_folder, folders, csv_name):
    news = []
    newstype = []
    for folder in folders:
        folder_path = data_folder + folder + '/'
        files = os.listdir(folder_path)
        for text_file in files:
            file_path = folder_path + "/" + text_file
            with open(file_path, errors='replace') as f:
                data = f.readlines()
            data = ' '.join(data)
            news.append(data)
            newstype.append(folder)

    datadict = {'news': news, 'type': newstype}

    df = pd.DataFrame(datadict)
    df.to_csv(data_folder + csv_name + '.csv')


def remove_stop_words(data, language='english'):
    sp = stopwords.words(language)
    data['news_without_stopwords'] = data['news'].apply(
        lambda x: ' '.join([word for word in x.split() if word not in sp]))


def stemming(data):
    ps = PorterStemmer()
    data['news_stemmed'] = data['news_without_stopwords'].apply(
        lambda x: ' '.join([ps.stem(word) for word in x.split()]))


def lower_case_and_punctation(data):
    data['news_stemmed'] = data['news_stemmed'].apply(lambda x: ' '.join(x.lower() for x in x.split()))
    data['news_stemmed'] = data['news_stemmed'].str.replace('[^\w\s]', '')


def frequency_filtering(data, count=5):
    frequency = pd.Series(' '.join(data['news_stemmed'])).value_counts()
    frequency_to_remove = frequency[frequency <= count]
    words_to_remove = list(frequency_to_remove.index.values)

    data['news_stemmed'] = data['news_stemmed'].apply(
        lambda x: ' '.join([word for word in x.split() if word not in words_to_remove]))


def topics_preprocessing(data):
    data['news_models'] = data['news_stemmed'].apply(
        lambda x: [word for word in x.split()])


def load_text(path):
    data = pd.read_csv(path)
    data = data.sample(n=len(data), random_state=0)
    return data


def preprocess_text(path, language='english', count=5):
    data = load_text(path)
    remove_stop_words(data, language)
    stemming(data)
    lower_case_and_punctation(data)
    frequency_filtering(data, count)
    topics_preprocessing(data)
    return data
