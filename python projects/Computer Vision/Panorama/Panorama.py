import numpy as np
import cv2 as cv


img1 = cv.imread("Slika3a.jpg")
img2 = cv.imread("Slika3b.jpg")
img3 = cv.imread("Slika3c.jpg")


def find(img1, img2):

    sift = cv.xfeatures2d.SIFT_create()

    kp1, des1 = sift.detectAndCompute(img1,None)
    kp2, des2 = sift.detectAndCompute(img2, None)

    index_params = dict(algorithm=1, trees=5)
    search_params = dict(checks=50)

    flann = cv.FlannBasedMatcher(index_params, search_params)
    matches = flann.knnMatch(des1, des2, k=2)

    good = []
    for m, n in matches:
        if m.distance < 0.5 * n.distance:
            good.append(m)

    if len(good) > 10:
        img1_pts = []
        img2_pts = []
        for m in good:
            img1_pts.append(kp1[m.queryIdx].pt)
            img2_pts.append(kp2[m.trainIdx].pt)
        img1_pts = np.float32(img1_pts).reshape(-1, 1, 2)
        img2_pts = np.float32(img2_pts).reshape(-1, 1, 2)
        M, mask = cv.findHomography(img1_pts, img2_pts, cv.RANSAC, 5.0)

        return M
    else:
        print("Nema dovoljno dobrih parova")


def conc(img1, img2, M):

    w1, h1 = img1.shape[:2]
    w2, h2 = img2.shape[:2]

    img1_dims = np.float32([[0, 0], [0, w1], [h1, w1], [h1, 0]]).reshape(-1, 1, 2)
    img2_dims_temp = np.float32([[0, 0], [0, w2], [h2, w2], [h2, 0]]).reshape(-1, 1, 2)

    img2_dims = cv.perspectiveTransform(img2_dims_temp, M)

    result_dims = np.concatenate((img1_dims, img2_dims), axis=0)

    [x_min, y_min] = np.int32(result_dims.min(axis=0).ravel() - 0.5)
    [x_max, y_max] = np.int32(result_dims.max(axis=0).ravel() + 0.5)

    transform_dist = [-x_min, -y_min]
    transform_array = np.array([[1, 0, transform_dist[0]], [0, 1, transform_dist[1]], [0, 0, 1]])

    result_img = cv.warpPerspective(img2, transform_array.dot(M), (x_max - x_min, y_max - y_min))
    result_img[transform_dist[1]:w1 + transform_dist[1], transform_dist[0]:h1 + transform_dist[0]] = img1

    return result_img


Matrix = find(img1, img2)
result = conc(img2, img1, Matrix)
Matrix = find(img3, result)
result = conc(result, img3, Matrix)

cv.imshow('Panorama', result)
cv.imwrite("Panorama.jpg",result)

if cv.waitKey(0) & 0xFF == ord('q'):
    cv.destroyAllWindows()