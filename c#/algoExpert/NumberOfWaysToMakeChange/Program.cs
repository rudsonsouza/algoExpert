// See https://aka.ms/new-console-template for more information

/*
 * Number of Ways to Make Change
 *
 * Given an array of distinct positive integers representing coin denominations and a single non-negative integer n
 * representing a target amount of money, write a function that returns the number of ways to make change for that
 * target amount using the given coin denominations.
 *
 * Note that an unlimited amount of coins is at your disposal.
 */

Console.WriteLine("Hello, World!");

// time O(nd) | space (n) where n is the target and d is the denomination
int[] denomination = new int[] { 1, 5, 10, 25 };
int target = 10;
var result = NumberOfWaysToMakeChange(target, denomination);

static int NumberOfWaysToMakeChange(int n, int[] denoms)
{
  int[] ways = new int[n + 1];
  ways[0] = 1;

  foreach (int denom in denoms)
  {
      for (int amount = 1; amount < n + 1; amount++)
      {
          if (denom <= amount)
          {
              ways[amount] += ways[amount - denom];
          }
      }
  }

  return ways[n];

}