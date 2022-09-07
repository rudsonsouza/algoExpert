class Solution(object):
    # time O(b^2 * r) | space O(b)
    def apartmentHunting01(blocks, reqs):
        maxDistancesAtBlocks = [float("-inf") for _ in blocks]
        for i in range(len(blocks)):
            for req in reqs:
                closestReqDistance = float("inf")
                for j in range(len(blocks)):
                    if blocks[j][req]:
                        closestReqDistance = min(closestReqDistance, distanceBetween(i, j))
                maxDistancesAtBlocks[i] = max(maxDistancesAtBlocks[i], closestReqDistance)
        return getIdxAtMinValue(maxDistancesAtBlocks)

    # time O(b * r) | space O(br + b)
    def apartmentHunting02(blocks, reqs):
        minDistancesFromBlocks = list(map(lambda req: getMinDistances(blocks, req), reqs)) # O(br)
        maxDistancesAtBlocks = getMaxDistancesAtBlocks(blocks, minDistancesFromBlocks) # O(br)
        return getIdxAtMinValue(maxDistancesAtBlocks) 

def getMinDistances(blocks, req):
    minDistances = [0 for _ in blocks]
    closestReqIdx = float("inf")
    for i in range(len(blocks)):
        if blocks[i][req]:
            closestReqIdx = i
        minDistances[i] = distanceBetween(i, closestReqIdx)
    for i in reversed(range(len(blocks))):
        if blocks[i][req]:
            closestReqIdx = i
        minDistances[i] = min(minDistances[i], distanceBetween(i, closestReqIdx))
    return minDistances

def getMaxDistancesAtBlocks(blocks, minDistancesFromBlocks):
    maxDistancesAtBlocks = [0 for block in blocks]
    for i in range(len(blocks)):
        minDistancesAtBlock = list(map(lambda distances: distances[i], minDistancesFromBlocks))
        maxDistancesAtBlocks[i] = max(minDistancesAtBlock)
    return maxDistancesAtBlocks

def distanceBetween(a, b):
    return abs(a - b)

def getIdxAtMinValue(array):
    idxAtMinValue = 0
    minValue = float("inf")
    for i in range(len(array)):
        currentValue = array[i]
        if currentValue < minValue:
            minValue = currentValue
            idxAtMinValue = i
    return idxAtMinValue

blocks = [
    {"gym": False, "school": True, "store": False},
    {"gym": True, "school": False, "store": False},
    {"gym": True, "school": True, "store": False},
    {"gym": False, "school": True, "store": False},
    {"gym": False, "school": True, "store": True},
]

reqs = ["gym", "school", "store"]

print(Solution.apartmentHunting02(blocks, reqs))