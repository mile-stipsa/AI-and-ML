from subprocess import call
from sklearn.tree import export_graphviz as expCART
from id3 import export_graphviz as expID3


def visualize_CART(model, columns):
    expCART(model, out_file='CART.dot', feature_names=columns, class_names='class', rounded=True, proportion=False,
            precision=2, filled=True)

    call(['C://Users/PC/Downloads/release/bin\dot', '-Tpng', 'CART.dot', '-o', 'CART.png', '-Gdpi=600'])


def visualize_ID3(model, columns):
    expID3(model, 'ID3.dot', columns)
    call(['C://Users/PC/Downloads/release/bin\dot', '-Tpng', 'ID3.dot', '-o', 'ID3.png', '-Gdpi=600'])

