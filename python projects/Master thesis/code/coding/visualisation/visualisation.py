import matplotlib.pyplot as plt
import seaborn as sns


def class_distribution(data, class_column, figure_name='class_distribution'):
    plt.clf()
    sns.set_style()
    sns.countplot(data[class_column])
    plt.savefig(figure_name+'.png')
