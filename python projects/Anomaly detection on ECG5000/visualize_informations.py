from load import *
from settings import *
from visualisation import visualize_class_pattern, visualize_class_distribution

print("Num GPUs Available: ", len(tf.config.experimental.list_physical_devices('GPU')))  # provera da li je omoguceno izvrsenje na GPU

train = load_data(TRAIN_DATA)
test = load_data(TEST_DATA)

data = concatenate_data(train, test)

visualize_class_pattern(data)  # vizuelizacija sablona klasa
visualize_class_distribution(data.target)  # vizuelizacija distribucije klasa
