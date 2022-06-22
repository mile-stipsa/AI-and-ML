import numpy as np
import cv2

# citanje i pretvaranje u frekventni domen
imgIn = cv2.imread("Slika7.png", flags=cv2.IMREAD_GRAYSCALE)
imgInF = np.float32(imgIn)
dft = cv2.dft(imgInF, flags=cv2.DFT_COMPLEX_OUTPUT) #pretvara sliku u frekventni domen
dft = np.fft.fftshift(dft) # vrsi zamenu kvadranata

# citanje i pretvaranje u frekventni domen
imgIn1 = cv2.imread("Slika8.png", flags=cv2.IMREAD_GRAYSCALE)
imgInF1 = np.float32(imgIn1)
dft1 = cv2.dft(imgInF1, flags=cv2.DFT_COMPLEX_OUTPUT) #pretvara sliku u frekventni domen
dft1 = np.fft.fftshift(dft1) # vrsi zamenu kvadranata

###############################################################

# Obrada u frekventnom domenu


# funkcija koja proverava da li se dati piksel nalazi u krugu
def inCircle(centerX, centerY, r, x, y):
    distance = (x - centerX) ** 2 + (y - centerY) ** 2
    return distance <= r ** 2


rows, cols = imgIn1.shape
centerX, centerY = int(rows/2), int(cols/2)

for x1 in range(rows):
    for y1 in range(cols):
        if inCircle(centerX, centerY, 20, x1, y1):
            dft1[x1, y1] = 0 # maskiranje niskih frekvencija, ostaju samo visoke, u drugoj slici
        if not inCircle(centerX, centerY, 20, x1, y1):
            dft[x1, y1] = 0 # maskiranje visokih frekvencija, ostaju samo niske, u prvoj slici

# dobijanje originalne slike
orgDFT = dft1+dft

###############################################################

dft = np.fft.ifftshift(dft)
dft1 = np.fft.ifftshift(dft1)
orgDFT = np.fft.ifftshift(orgDFT)


imgOutF = cv2.idft(dft, flags=cv2.DFT_INVERSE | cv2.DFT_SCALE | cv2.DFT_REAL_OUTPUT)
imgOutF = np.clip(imgOutF, 0, 255)
imgOut = np.uint8(imgOutF)

imgOutF1 = cv2.idft(dft1, flags=cv2.DFT_INVERSE | cv2.DFT_SCALE | cv2.DFT_REAL_OUTPUT)
imgOutF1 = np.clip(imgOutF1, 0, 255)
imgOut1 = np.uint8(imgOutF1)

imgOutF12 = cv2.idft(orgDFT, flags=cv2.DFT_INVERSE | cv2.DFT_SCALE | cv2.DFT_REAL_OUTPUT)
imgOutF12 = np.clip(imgOutF12, 0, 255)
imgHybrid = np.uint8(imgOutF12)


cv2.imwrite("IzlaznaSlika.png", imgHybrid)
cv2.imshow("Image 1", imgOut)
cv2.imshow("Image 2", imgOut1)
cv2.imshow("Hybrid image", imgHybrid)

if cv2.waitKey(0) & 0xFF == ord('q'):
    cv2.destroyAllWindows()
