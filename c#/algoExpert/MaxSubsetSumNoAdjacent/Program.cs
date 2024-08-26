// See https://aka.ms/new-console-template for more information
/* Write a function that takes in an array of positive integers and returns the maximum sum of non-adjacent 
 * elements in the array.
 * 
 * If the input array is empty, the function should return 0.
 * 
 */
Console.WriteLine("Hello, World!");

// time O(n) | space O(n)
/*
 * [7, 10, 12, 7, 9, 14]
 * [7, 10, 19, 19, 28, 33]
 *  maxSums[2] = max(maxSums[1], maxSums[0] + maxSums[2])
 * 
 */

/*
static int MaxSubsetSumNoAdjacentMethod(int[] array)
{ 
  if (array.Length == 0)
  {
    return 0;
  }
  else if (array.Length == 1)
  {
    return array[0]; 
  }

  int[] maxSums = (int[])array.Clone();
  maxSums[1] = Math.Max(array[0], array[1]);

  for (int i = 2; i < array.Length; i++)
  {
      maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + maxSums[i]);
  }

  return maxSums[array.Length - 1];
}
*/

// time O(n) | space O(1)
static int MaxSubsetSumNoAdjacentMethod(int[] array)
{ 
    if (array.Length == 0)
    {
        return 0;
    }
    else if (array.Length == 1)
    {
        return array[0]; 
    }

    int second = array[0];
    int first = Math.Max(array[0], array[1]);

    for (int i = 2; i < array.Length; i++)
    {
        int current = Math.Max(first, second + array[i]);
        second = first;
        first = current;
    }

    return first;
}

var maxSubsetSum = MaxSubsetSumNoAdjacentMethod(new int[] { 75, 105, 120, 75, 90, 135 });
Console.WriteLine(maxSubsetSum);
{
    
}

