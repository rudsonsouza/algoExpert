class Solution(object):
    # Average: time O(n^2) | space O(n^2)
    # Worst: time O(n^3) | space O(n^2)
    def fourNumberSum(array, targetSum):
        allPairsSum = {}
        quadruplets = []

        for i in range(1, len(array) - 1):
            for j in range(i + 1, len(array)):
                currentSum = array[i] + array[j]
                difference = targetSum - currentSum
                if difference in allPairsSum:
                    for pair in allPairsSum[difference]:
                        quadruplets.append(pair + [array[i], array[j]])
            
            for k in range(0, i):
                currentSum = array[i] + array[k]
                if currentSum not in allPairsSum:
                    allPairsSum[currentSum] = [[array[k], array[i]]]
                else:
                    allPairsSum[currentSum].append([array[k], array[i]])
        return quadruplets

print(Solution.fourNumberSum([7, 6, 4, -1, 1, 2], 16))