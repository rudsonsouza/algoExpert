class Solution(object):
    # time O(n^2) | space O(n)
    def firstDuplicateValue01(array):
        minimumSecondIndex = len(array)
        for i in range(len(array)):
            value = array[i]
            for j in range(i + 1, len(array)):
                valueToCompare = array[j]
                if value == valueToCompare:
                    minimumSecondIndex = min(minimumSecondIndex, j)
        
        if minimumSecondIndex == len(array):
            return -1
        
        return array[minimumSecondIndex]

    # time O(n) | space O(n)
    def firstDuplicateValue02(array):
        seen = set()
        for value in array:
            if value in seen:
                return value
            seen.add(value)
        return -1
    
    # time O(n) | space O(1)
    def firstDuplicateValue03(array):
        for value in array:
            absValue = abs(value)
            if array[absValue - 1] < 0:
                return absValue
            array[absValue - 1] *= -1
        return -1

print(Solution.firstDuplicateValue03([2, 1, 5, 2, 3, 3, 4]))