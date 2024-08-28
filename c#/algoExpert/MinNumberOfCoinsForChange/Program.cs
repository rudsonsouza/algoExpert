// See https://aka.ms/new-console-template for more information
/* Min number of coins for change
 *
 * Given an array of positive integers representing coin denominations and a
 * single non-negative integer n representing a target amount of money, write
 * a function that returns the smallest number of coins needed to make change
 * for (to sum up to) that target amount using the given coin denominations.
 *
 * Note that you have access to an unlimited amount of coins. In other words,
 * if the denominations are [1, 5, 10], you have access to an unlimited amount
 * of 1s, 5s and 10s.
 *
 * If it's impossible to make change for the target amount, return -1.
 */
Console.WriteLine("Hello, World!");

int n = 7;
int[] denoms = new int[] {1, 5, 10};


// Time O(nd) | Space O(n)
static int MinNumberOfCoinsForChange(int n, int[] denoms)
{
    int[] numOfCoins = new int[n + 1];
    Array.Fill(numOfCoins, Int32.MaxValue);

    numOfCoins[0] = 0;
    int toCompare = 0;
    
    foreach (int denom in denoms)
    {
        for (int amount = 0; amount <= numOfCoins.Length; amount++)
        {
            if (denom <= amount)
            {
                if (numOfCoins[amount - denom] == Int32.MaxValue)
                {
                    toCompare = numOfCoins[amount - denom];
                }
                else
                {
                    toCompare = numOfCoins[amount - denom] + 1;
                }

                numOfCoins[amount] = Math.Min(numOfCoins[amount], toCompare);
            }
        }
    }

    return numOfCoins[n] != Int32.MaxValue ? numOfCoins[n] : -1;
}