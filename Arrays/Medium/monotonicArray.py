class Solution(object):
    def isMonotonic(array):
        if len(array) <= 2:
            return True
        
        direction = array[1] - array[0]
        for i in range(2, len(array)):
            if direction == 0:
                direction = array[i] - array[i - 1]
                continue

            if breaksDirection(direction, array[i - 1], array[i]):
                return False
        
        return True

def breaksDirection(direction, previous, current):
        difference = current - previous
        if direction > 0:
            return difference < 0
            
        return difference > 0


print(Solution.isMonotonic([-1, -5, -10, -1100, -1101, -1102, -9001]))