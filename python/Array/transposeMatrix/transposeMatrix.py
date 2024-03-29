# O(w * h) time | O(w * h) space - where w is the
# width of the matrix and h is the height
def transposeMatrix(matrix):
    transposedMatrix = []
    for col in range(len(matrix[0])):
        newRow = []
        for row in range(len(matrix)):
            newRow.append(matrix[row][col])
        transposedMatrix.append(newRow)
    return transposedMatrix


matrixRequest = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
transposeMatrix(matrixRequest)
