import cv2 as cv
import dlib

faceDetector = cv.CascadeClassifier("haarcascade_frontalface_alt.xml")

predictor_path = "shape_predictor_68_face_landmarks.dat"
predictor = dlib.shape_predictor(predictor_path)

cap = cv.VideoCapture(0)

while True:

    rects = dlib.rectangles()

    ret, img = cap.read()
    gray = cv.cvtColor(img, cv.COLOR_BGR2GRAY)

    #pravougaonik plave boje, linija za bradu crvene boje, i ostalo zelene boje
    faces = faceDetector.detectMultiScale(gray, 1.2, 3)
    for (x, y, w, h) in faces:
        cv.rectangle(img, (x, y), (x + w, y + h), (255, 0, 0), 1)
        rects.append(dlib.rectangle(int(x), int(y), int(x + w), int(y + h)))

    for rect in rects:
        shape = predictor(gray, rect)

        #brada
        for i in range(0, 16):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 0, 255), 1)
        #leva obrva
        for i in range(17, 21):
                cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y),(0, 255, 0),1)
        #desna obrva
        for i in range(22, 26):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        #nos
        for i in range(27, 30):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y),(0, 255, 0), 1)
        for i in range(31, 35):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        #levo oko
        for i in range(36, 41):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        cv.line(img, (shape.part(36).x, shape.part(36).y), (shape.part(41).x, shape.part(41).y), (0, 255, 0), 1)
        #desno oko
        for i in range(42, 47):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        cv.line(img, (shape.part(42).x, shape.part(42).y), (shape.part(47).x, shape.part(47).y), (0, 255, 0), 1)
        #usta
        for i in range(48, 59):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        cv.line(img, (shape.part(48).x, shape.part(48).y), (shape.part(59).x, shape.part(59).y), (0, 255, 0), 1)
        for i in range(60, 67):
            cv.line(img, (shape.part(i).x, shape.part(i).y), (shape.part(i + 1).x, shape.part(i + 1).y), (0, 255, 0), 1)
        cv.line(img, (shape.part(60).x, shape.part(60).y), (shape.part(67).x, shape.part(67).y), (0, 255, 0), 1)

    cv.imshow("Face detection", img)

    if cv.waitKey(1) & 0xFF == ord("q"):
        break

cap.release()
cv.destroyAllWindows()
