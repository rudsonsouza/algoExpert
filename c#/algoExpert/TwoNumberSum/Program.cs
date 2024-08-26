/* Write a function that takes in a non-empty array of distinct integers and an integer
 * representing a target sum. If any two numbers in the input array sum, the function
 * should return them in an array, in any order. If no two numbers sum up to the target sum,
 * the function should return an empty array.
 *
 * Note that the target sum has to be obtained by summing two different integers in the
 * array; you cant add a single integer to itself in order to obtain the target sum.
 *
 * You can assume that there will be at most one pair of numbers summing up to the target
 * sum.
 *
 * Sample input: array [3, 5, -4, 8, 11, 1, -1, 6]; targetSum = 10
 */
 
// Solution 01 
/*
static int[] TwoNumberSum(int[] array, int targetSum)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int firstNum = array[i];
        for (int j = i + 1; j < array.Length; j++)
        {
            int secondNum = array[j];
            if (firstNum + secondNum == targetSum) return new int[] { firstNum, secondNum };
        }
    }
    
    return new int[0];
}
*/

// Solution 02: Time O(n) | Space O(n)
/*
static int[] TwoNumberSum(int[] array, int targetSum)
{
    HashSet<int> nums = new HashSet<int>();
    foreach (int num in array)
    {
        int potentialMatch = targetSum - num;
        if (nums.Contains(potentialMatch))
        {
            return new int[] { num, potentialMatch };
        }
        else
        {
            nums.Add(num);
        }
    }
    
    return new int[0];
}
*/

// Solution 03: Time O(n log(n)) | Space O(1)
static int[] TwoNumberSum(int[] array, int targetSum)
{
    Array.Sort(array);
    int left = 0;
    int right = array.Length - 1;

    while (left < right)
    {
        int currentSum = array[left] + array[right];
        if (currentSum == targetSum)
        {
            return new int[] { array[left], array[right] };            
        }
        else if (currentSum < targetSum)
        {
            left++;
        }
        else if (currentSum > targetSum)
        {
            right --;
        }
    }

    return new int[0];
}

var output = TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6}, 10);

