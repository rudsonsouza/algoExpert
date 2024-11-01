/*
 * Min Number of Jumps
 *
 * You're given a non-empty array of positive integers where each integer represents the
 * maximum number of steps you can take forward in the array. For example, if the
 * element at index 1 is 3, you can go from index 1 to index 2, 3, or 4.
 *
 * Write a function that returns the minimum number of jumps needed to reach the final
 * index.
 *
 * Note that jumping from index i to index i + x always constitutes one jump, no
 * matter how large x is.
 */

var array = new int[]{ 3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3 };
var result = MinNumberOfJumpsV1(array);
result = MinNumberOfJumpsV2(array);

static int MinNumberOfJumpsV1(int[] array)
{
    int[] jumps = new int[array.Length];
    Array.Fill(jumps, Int32.MaxValue);
    jumps[0] = 0;
    for (int i = 1; i < array.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (array[j] + j >= i)
            {
                jumps[i] = Math.Min(jumps[j] + 1, jumps[i]);
            }
        }
    }

    return jumps[jumps.Length - 1];
}

static int MinNumberOfJumpsV2(int[] array)
{
    if (array.Length == 1) return 0;

    int jumps = 0;
    int maxReach = array[0];
    int steps = array[0];

    for (int i = 1; i < array.Length - 1; i++)
    {
        maxReach = Math.Max(maxReach, i + array[i]);
        steps -= 1;
        if (steps == 0)
        {
            jumps += 1;
            steps = maxReach - i;
        }
    }
    
    return jumps + 1; 
}