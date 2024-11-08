/*
 * Maximize Expression
 *
 * Write a function that takes in an array of integers and returns the largest
 * possible value for the expression
 * array[a] - array[b] + array[c] - array[d], where a, b, c, and
 * d are indices of the array and a < b < c < d.
 *
 * If the input array has fewer than 4 elements, your function should return 0.
*/

int[] input = new int[] { 3, 6, 1, -3, 2, 7 };
var result = MaximizeExpression(input);

static int MaximizeExpression(int[] array)
{
    if (array.Length < 4) return 0;
    
    List<int> maxOfA = new List<int>() { array[0] };
    List<int> maxOfAMinusB = new List<int>() { Int32.MinValue };
    List<int> maxOfAMinusBPlusC = new List<int>() { Int32.MinValue, Int32.MinValue };
    List<int> maxOfAMinusBPlusCMinusD = new List<int>() { Int32.MinValue, Int32.MinValue, Int32.MinValue };

    for (int idx = 1; idx < array.Length; idx++)
    {
        int currentMax = Math.Max(maxOfA[idx - 1], array[idx]);
        maxOfA.Add(currentMax);
    }

    for (int idx = 1; idx < array.Length; idx++)
    {
        int currentMax = Math.Max(maxOfAMinusB[idx - 1], maxOfA[idx - 1] - array[idx]);
        maxOfAMinusB.Add(currentMax);
    }

    for (int idx = 2; idx < array.Length; idx++)
    {
        int currentMax = Math.Max(maxOfAMinusBPlusC[idx - 1], maxOfAMinusB[idx - 1] + array[idx]);
        maxOfAMinusBPlusC.Add(currentMax);
    }

    for (int idx = 3; idx < array.Length; idx++)
    {
        int currentMax = Math.Max(maxOfAMinusBPlusCMinusD[idx - 1], maxOfAMinusBPlusC[idx - 1] + array[idx]);
        maxOfAMinusBPlusCMinusD.Add(currentMax);
    }
    
    return maxOfAMinusBPlusCMinusD[maxOfAMinusBPlusCMinusD.Count - 1];
}