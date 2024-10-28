/*
 * Max Sum Increasing Subsequence
 *
 * Write a function that takes in a non-empty array of integers and returns the greatest sum that can be
 * generated from a strictly-increasing subsequence in the array as well as an array of the numbers in that
 * subsequence.
 *
 * A subsequence of an array is a set of numbers that aren't necessarily adjacent in the array but that are in
 * the same order as they appear in the array. For instance, the numbers [1, 3, 4] form a subsequence of
 * the array [1, 2, 3, 4], and so do the numbers [2, 4]. Note that a single
 * number in an array and the array itself are both valid subsequences of the array.
 *
 * You can assume that there will only be one increasing subsequence with the greatest sum.
 */

//var array = new int[]{ 10, 70, 20, 30, 50, 11, 30 };
var array = new int[] { -1 };
var result = MaxSumIncreasingSubsequence(array);

foreach (var itemResult in result)
{
    foreach (var item in itemResult)
    {
        Console.WriteLine(item);   
    }
}

static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
{
    int n = array.Length;
    if (n == 0) return new List<List<int>>();
    
    int[] previousIndex = new int[n];

    // Initialize dp and previousIndex
    Array.Fill(previousIndex, Int32.MinValue);
    int[] dp = (int[])array.Clone();

    // Fill dp array and keep track of previous indices
    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (array[i] > array[j] && dp[i] < dp[j] + array[i])
            {
                dp[i] = dp[j] + array[i];
                previousIndex[i] = j;
            }
        }
    }
    
    // Find the maximum sum
    int maxSum = Int32.MinValue;
    for (int i = 0; i < n; i++)
    {
        if (dp[i] > maxSum)
        {
            maxSum = dp[i];
        }
    }
    
    // Collect all subsequences that give the maximum sum
    var subsequences = new List<List<int>>();
    subsequences.Add(new List<int>() { maxSum });
    
    // To find the subsequences, backtrack through the dp array
    for (int i = 0; i < n; i++)
    {
        if (dp[i] == maxSum)
        {
            List<int> subsequence = new List<int>();
            int currentIndex = i;

            // Backtrack to form the subsequence
            while (currentIndex != Int32.MinValue)
            {
                subsequence.Insert(0, array[currentIndex]);
                currentIndex = previousIndex[currentIndex];
            }
            
            subsequences.Add(subsequence);
        }
    }
    
    return subsequences;
}
/*
static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
{
    int[] sequences = new int[array.Length];
    Array.Fill(sequences, Int32.MinValue);
    int[] sums = (int[])array.Clone();
    int maxSumIdx = 0;

    for (int i = 0; i < array.Length; i++)
    {
        int currentNum = array[i];
        
        for (int j = 0; j < i; j++)
        {
            int otherNum = array[j];
            if (otherNum < currentNum && sums[j] + currentNum >= sums[i])
            {
                sums[i] = sums[j] + currentNum;
            }
        }

        if (sums[i] >= sums[maxSumIdx])
        {
            maxSumIdx = i;
        }
    }
    
    return buildSequence(array, sequences, maxSumIdx, sums[maxSumIdx]);
}

static List<List<int>> buildSequence(int[] array, int[] sequences, int maxSumIdx, int sum)
{
    List<List<int>> sequence = new List<List<int>>();
    sequence.Add(new List<int>());
    sequence.Add(new List<int>());
    sequence[0].Add(sum);
    while (maxSumIdx != Int32.MinValue)
    {
        sequence[1].Insert(0, array[maxSumIdx]);
        maxSumIdx = sequences[maxSumIdx];
    }

    return sequence;
}
*/