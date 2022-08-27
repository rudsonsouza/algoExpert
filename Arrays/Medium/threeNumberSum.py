class Solution(object):
    def threeNumberSum(array, targetSum):
        array.sort()
        result = []

        for i in range(len(array) - 2):
            leftPointer = i + 1
            rightPointer = len(array) - 1

            while leftPointer < rightPointer:
                currentSum = array[i] + array[leftPointer] + array[rightPointer]
                if currentSum == targetSum:
                    result.append([array[i], array[leftPointer], array[rightPointer]])
                    leftPointer += 1
                    rightPointer -= 1
                elif currentSum < targetSum:
                    leftPointer += 1
                else: rightPointer -= 1
        return result

print(Solution.threeNumberSum([12, 3, 1, 2, -6, 5, -8, 6], 0))