from sklearn.metrics import accuracy_score
from sklearn import tree
from id3 import Id3Estimator
import visualisation as vs
import time as t


def ID3(train, train_labels, test, test_labels, col):
    model = Id3Estimator(prune=True)
    start_time = t.time()
    model = model.fit(train, train_labels)

    y_predicted = model.predict(test)

    print('Elapsed time ID3:  %s seconds' % (t.time() - start_time))
    print('Accuracy of ID3: ' + str(accuracy_score(test_labels, y_predicted)))
    vs.visualize_ID3(model.tree_, col)


def CART(train, train_labels, test, test_labels, col):
    model = tree.DecisionTreeClassifier()
    start_time = t.time()
    model = model.fit(train, train_labels)

    y_predicted = model.predict(test)

    print('Elapsed time CART:  %s seconds' % (t.time() - start_time))
    print('Accuracy of CART: ' + str(accuracy_score(test_labels, y_predicted)))
    vs.visualize_CART(model, col)
