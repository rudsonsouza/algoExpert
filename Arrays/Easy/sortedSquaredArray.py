from optparse import Values


class Solution(object):
    # time (n logn) | space
    def sortedSquaredArray(self, array):
        sortedSquares = [0 for _ in array]

        for idx in range(len(array)):
            value = array[idx]
            sortedSquares[idx] = value * value
        sortedSquares.sort()
        return sortedSquares

print(Solution().sortedSquaredArray([1, 2, 3, 5, 6, 8, 9]))