/*
 * Dice Throws
 *
 * You're given a set of numDice dice, each with numSides sides, and a
 * target integer, which represents a target sum to obtain when rolling all of
 * the dice and summing their values. Write a function that returns the total
 * number of dice-roll permutations that sum up to exactly that target value.
 *
 * All three input values will always be positive integers. Each of the dice has an
 * equal probability of landing on any number from 1 to numSides. Identical
 * total dice rolls obtained from different individual dice rolls (for example,
 * [2, 3] vs. [3, 2]) count as different dice-roll permutations. If there's no
 * possible dice-roll combination that sums up to the target given the input
 * dice, your function should return 0.
*/

var numDice = 2;
var numSides = 6;
var target = 7;
var result = DiceThrows(numDice, numSides, target);

static int DiceThrows(int numDice, int numSides, int target)
{
    int[,] storedResults = new int[2, target + 1];
    storedResults[0, 0] = 1;

    int previousNumDiceIndex = 0;
    int newNumDiceIndex = 1;

    for (int currentNumDice = 0; currentNumDice < numDice; currentNumDice++)
    {
        for (int currentTarget = 0; currentTarget <= target; currentTarget++)
        {
            int numWaysToReachTarget = 0;
            for (int currentNumSides = 1; 
                 currentNumSides <= Math.Min(currentTarget, numSides); 
                 currentNumSides++)
            {
                numWaysToReachTarget += storedResults[previousNumDiceIndex, currentTarget - currentNumSides];
            }

            storedResults[newNumDiceIndex, currentTarget] = numWaysToReachTarget;
        }

        int tempPreviousNumDiceIndex = previousNumDiceIndex;
        previousNumDiceIndex = newNumDiceIndex;
        newNumDiceIndex = tempPreviousNumDiceIndex;
    }

    return storedResults[previousNumDiceIndex, target];
}

// O(d * s * t) time | O(d * t) space
/*
static int DiceThrows(int numDice, int numSides, int target)
{
    int[,] storedResults = new int[numDice + 1, target + 1];
    storedResults[0, 0] = 1;

    for (int currentNumDice = 1; currentNumDice <= numDice; currentNumDice++)
    {
        for (int currentTarget = 0; currentTarget <= target; currentTarget++)
        {
            int numWaysToReachTarget = 0;
            for (int currentNumSides = 1; 
                 currentNumSides <= Math.Min(currentTarget, numSides); 
                 currentNumSides++)
            {
                numWaysToReachTarget += storedResults[currentNumDice - 1, currentTarget - currentNumSides];
            }

            storedResults[currentNumDice, currentTarget] = numWaysToReachTarget;
        }
    }

    return storedResults[numDice, target];
}
*/

// O(d * s * t) time | O(d * t) space
/*
static int DiceThrows(int numDice, int numSides, int target)
{
    int[,] storedResults = new int[numDice + 1, target + 1];
    for (var i = 0; i < storedResults.GetLength(0); i++)
    {
        for (var j = 0; j < storedResults.GetLength(1); j++)
        {
            storedResults[i, j] = -1;
        }
    }
    
    return DiceThrowsHelper(numDice, numSides, target, storedResults);
}

static int DiceThrowsHelper(int numDice, int numSides, int target, int[,] storedResults)
{
    if (numDice == 0) return target == 0 ? 1 : 0;
    
    if (storedResults[numDice, target] != -1)  return storedResults[numDice, target];

    int numWaysToReachTarget = 0;
    for (int currentTarget = Math.Max(0, target - numSides); currentTarget < target; currentTarget++)
    {
        numWaysToReachTarget += DiceThrowsHelper(numDice - 1, numSides, currentTarget, storedResults);
    }

    storedResults[numDice, target] = numWaysToReachTarget;

    return numWaysToReachTarget;
}
*/