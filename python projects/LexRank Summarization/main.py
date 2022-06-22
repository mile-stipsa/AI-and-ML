import input_output as io
import summarization as sm

# ucitavanje i preprocesiranje tekstova
stemmed, real = io.load_sentences('bbc')

# sumarizacija recenica po klasterima
sm.show_clusters_summary(stemmed, real, 5, 300, 5, 0.8)

