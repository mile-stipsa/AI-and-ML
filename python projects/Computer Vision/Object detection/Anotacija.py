import numpy as np
import time
import cv2
import imutils


def pyramid(image_in, scale=1.2, min_size=(30, 30)):
    yield image_in

    while True:
        w1 = int(image_in.shape[1] / scale)
        image_in = imutils.resize(image, width=w1)
        if image_in.shape[0] < min_size[0] or image_in.shape[1] < min_size[1]:
            break
        yield image_in


def sliding_window(image_in, step_size, window_size):
    for y1 in range(0, image_in.shape[0], step_size):
        for x1 in range(0, image_in.shape[1], step_size):
            yield (x1, y1, image_in[y1:y1 + window_size[1], x1:x1 + window_size[0]])


def get_top_left(x_old, y_old, x_new, y_new):
    return min(x_new, x_old), min(y_new, y_old)


def get_bottom_right(x_old, y_old, x_new, y_new):
    return max (x_new, x_old), max (y_new, y_old)


def get_rectangle(old_rectangle_params, x_new, y_new, h_new, w_new, p_new):
    x1, y1, h1, w1, p1 = old_rectangle_params
    x_left, y_top = get_top_left(x1, y1, x_new, y_new)
    x_right, y_bottom = get_bottom_right(x1 + w1, y1 + h1, x_new + w_new, y_new + h_new)
    p_max = max(p1, p_new)
    return x_left, y_top, y_bottom - y_top, x_right - x_left, p_max


image = cv2.imread("images/street.jpg")
image1 = image.copy()

rows = open("synset_words.txt").read().strip().split("\n")
classes = [r[r.find(" ") + 1:].split(",")[0] for r in rows]

colors = np.random.uniform(0, 255, size=(len(classes), 3))
net = cv2.dnn.readNetFromCaffe("bvlc_googlenet.prototxt", "bvlc_googlenet.caffemodel")

(winW, winH) = (128, 128)

founded_classes = {}
sc = 1

for resized in pyramid(image, scale=1.2):
    for (x, y, window) in sliding_window(resized, step_size=32, window_size=(winW, winH)):
        if window.shape[0] != winH or window.shape[1] != winW:
            continue

        blob = cv2.dnn.blobFromImage(window, 1, (224, 224), (104, 117, 123))
        net.setInput(blob)
        preds = net.forward()

        idxs = np.argsort(preds[0])[::-1][:10]

        for idx in idxs:
            if preds[0][idx] > 0.9:
                if idx not in founded_classes:
                    founded_classes[idx] = (int(x*sc), int(y*sc), int(winH*sc), int(winW*sc), preds[0][idx])
                elif idx in founded_classes:
                    founded_classes[idx] = get_rectangle(founded_classes[idx], int(x*sc), int(y*sc), int(winH*sc),
                                                         int(winW*sc), preds[0][idx])

        clone = resized.copy()
        cv2.rectangle(clone, (x, y), (x + winW, y + winH), (0, 255, 0), 2)
        cv2.imshow("Window", clone)
        cv2.waitKey(1)
        time.sleep(0.005)

    sc = sc*1.2


for idx in founded_classes:
    (x, y, h, w, p) = founded_classes[idx]
    label = "{}: {:.2f}%".format(classes[idx], p * 100)
    cv2.putText(image1, label, (x + 10, y + 20), cv2.FONT_HERSHEY_COMPLEX, 0.7, colors[idx])
    cv2.rectangle(image1, (x, y), (x + w, y + h), colors[idx], 2)

cv2.imshow("Annotated image", image1)

cv2.waitKey(0)
