import enum

class Solution(object):
    # time O(n^2) | space O(1)
    def twoNumberSum01(self, array, targetSum):
        for i in range(len(array) - 1):
            firstNum = array[i]
            for j in range(i + 1, len(array)):
                secondNum = array[j]
                if firstNum + secondNum == targetSum:
                    return [firstNum, secondNum]
        return []
    
    # time O(n) | space(n)
    def twoNumberSum02(self, array, targetSum):
        nums = {}
        for num in array:
            potentialMatch = targetSum - num
            if potentialMatch in nums:
                return [potentialMatch, num]
            else:
                nums[num] = True
        return []
    
    # version return value
    # time O(nlog(n)) | space O(1)
    def twoNumberSum03(self, array, targetSum):
        array.sort()
        left = 0
        right = len(array) - 1
        while left < right:
            currentSum = array[left] + array[right]
            if currentSum == targetSum:
                return [array[left], array[right]]
            elif currentSum < targetSum:
                left += 1
            elif currentSum > targetSum:
                right -= 1
        return []

    # version return indices
    # time O(n) | space O(n)
    def twoNumberSum04(self, array, targetSum):
        values = {}
        for i, num in enumerate(array):
            diff = targetSum - num
            if diff in values:
                return [i, values[diff]]
            values[num] = i
        return []

print(Solution().twoNumberSum04([2,7,11,15], 18))