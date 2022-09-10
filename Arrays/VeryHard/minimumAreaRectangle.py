class Solution(object):
    # time O(n^2) | space O(n)
    def minimumAreaRectangle01(points):
        columns = initializeColumns(points)
        minimumAreaFound = float('inf')
        edgesParallelToYAxis = {}
        sortedColumns = sorted(columns.keys())

        for x in sortedColumns:
            yValuesInCurrentColumn = columns[x]
            yValuesInCurrentColumn.sort()

            for currentIdx, y2 in enumerate(yValuesInCurrentColumn):
                for previousIdx in range(currentIdx):
                    y1 = yValuesInCurrentColumn[previousIdx]
                    pointString = str(y1) + ":" + str(y2)
                    if pointString in edgesParallelToYAxis:
                        currentArea = (x - edgesParallelToYAxis[pointString]) * (y2 - y1)
                        minimumAreaFound = min(minimumAreaFound, currentArea)
                    edgesParallelToYAxis[pointString] = x
        return minimumAreaFound if minimumAreaFound != float('inf') else 0
        
    # time O(n^2) | space O(n)
    def minimumAreaRectangle02(points):
        pointSet = createPointSet(points)
        minimumAreaFound = float('inf')

        for currentIdx, p2 in enumerate(points):
            p2x, p2y = p2

            for previousIdx in range(currentIdx):
                p1x, p1y = points[previousIdx]
                pointsShareValue = p1x == p2x or p1y == p2y

                if pointsShareValue:
                    continue

                point1OnOppositeDiagonalExists = convertPointToString(p1x, p2y) in pointSet
                point2OnOppositeDiagonalExists = convertPointToString(p2x, p1y) in pointSet
                oppositeDiagonalExists = point1OnOppositeDiagonalExists and point2OnOppositeDiagonalExists

                if oppositeDiagonalExists:
                    currentArea = abs(p2x - p1x) * abs(p2y - p1y)
                    minimumAreaFound = min(minimumAreaFound, currentArea)
        return minimumAreaFound if minimumAreaFound != float('inf') else 0


def initializeColumns(poinsts):
    columns = {}
    for point in points:
        x, y = point
        if x not in columns:
            columns[x] = []
        columns[x].append(y)
    return columns

def createPointSet(points):
    pointSet = set()

    for point in points:
        x, y = point
        pointString = convertPointToString(x, y)
        pointSet.add(pointString)
    return pointSet

def convertPointToString(x, y):
    return str(x) + ":" + str(y)

points = [
  [1, 5],
  [5, 1],
  [4, 2],
  [2, 4],
  [2, 2],
  [1, 2],
  [4, 5],
  [2, 5],
  [-1, -2]   
]
print(Solution.minimumAreaRectangle02(points))