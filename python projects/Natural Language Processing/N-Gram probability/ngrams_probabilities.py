import ngrams as ng
import file as f

print('Loading text...')
data = f.load_data("data.txt")
print('Successfully loaded text')

print('Extracting tokens...')
tokens, data_new = ng.tokenize_data(data)
print('Tokens successfully extracted')

print('Creating ngrams...')
ngrams = ng.create_ngrams(tokens, 11)
print('Ngrams successfully created')

print('Calculating probabilities...')
probability_k1 = ng.probability_k1(ngrams, data_new)
probability_k2 = ng.probability_k2(ngrams, data_new)
print('Probabilities successfully calculated')

print('Saving probabilities...')
f.save_data('ngrams_probability_k1.txt', probability_k1)
f.save_data('ngrams_probability_k2.txt', probability_k2)
print('Probabilities successfully saved')
