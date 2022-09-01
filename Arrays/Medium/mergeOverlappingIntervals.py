class Solution(object):
    def mergeOverlappingIntervals(intervals):
        results = []
        sortedIntervals = sorted(intervals, key=lambda x: x[0])
        for start, end in sortedIntervals:
            if results and start <= results[-1][1]:
                prev_start, prev_end = results[-1]
                results[-1] = (prev_start, max(prev_end, end))
            else:
                results.append((start, end))
        return results

    def mergeOverlappingIntervalsAlgoExpert(intervals):
        sortedIntervals = sorted(intervals, key=lambda x: x[0])

        mergedIntervals = []
        currentInterval = sortedIntervals[0]
        mergedIntervals.append(currentInterval)

        for nextInterval in sortedIntervals:
            _, currentIntervalEnd = currentInterval
            nextIntervalStart, nextIntervalEnd = nextInterval

            if (currentIntervalEnd >= nextIntervalStart):
                currentInterval[1] = max(currentIntervalEnd, nextIntervalEnd)
            else:
                currentInterval = nextInterval
                mergedIntervals.append(currentInterval)
        
        return mergedIntervals

print(Solution.mergeOverlappingIntervalsAlgoExpert([[1, 2], [3, 5], [4, 7], [6, 8], [9, 10]]))