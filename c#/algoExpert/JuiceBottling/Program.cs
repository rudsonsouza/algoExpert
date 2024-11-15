/*
 * Juice Bottling
 *
 * You're given an array of integers prices of length n with the retail prices of various quantities of juice. Each
 * index in this array corresponds to the price of that amount of juice. For example, prices[2] would be the retail
 * price of 2 units of juice.
 *
 * You have n - 1 total units of juice. For example, if the length of prices is 5, then you would have 4 total units
 * of juice. Write a function to determine the optimal way to bottle the juice such that it maximizes revenue. This
 * function should return a list of all of the juice quantities required in ascending order.
 *
 * Note that the first value in the prices array will always be 0, because there is no value in no juice. All other values
 * will be positive integers. Additionally, a larger quantity of juice will not always be more expensive than a smaller
 * quantity. For simplicity, all of the test cases only have one possible solution.
*/

var input = new int[] { 0, 1, 3, 2, 4 };
var result = JuiceBottling(input);

// O(nˆ2) time | O(n) space
static List<int> JuiceBottling(int[] prices)
{
    int numSizes = prices.Length;
    int[] maxProfit = new int[numSizes];
    int[] dividingPoints = new int[numSizes];

    for (int size = 0; size < numSizes; size++)
    {
        for (int dividingPoint = 0; dividingPoint <= size; dividingPoint++)
        {
            int possibleProfit = maxProfit[size - dividingPoint] + prices[dividingPoint];
            if (possibleProfit > maxProfit[size])
            {
                maxProfit[size] = possibleProfit;
                dividingPoints[size] = dividingPoint;
            }
        }
    }
    
    List<int> solution = new List<int>();
    int currentDividingPoint = numSizes - 1;
    while (currentDividingPoint > 0)
    {
        solution.Add(dividingPoints[currentDividingPoint]);
        currentDividingPoint -= dividingPoints[currentDividingPoint];
    }

    return solution;
}

// O(n^3) time | O(n^2) space
/*
static List<int> JuiceBottling(int[] prices)
{
    int numSizes = prices.Length;
    int[] maxProfit = new int[numSizes];
    List<List<int>> solutions = new List<List<int>>();
    for (int size = 0; size < numSizes; size++)
    {
        solutions.Add(new List<int>());
    }

    for (int size = 0; size < numSizes; size++)
    {
        for (int dividingPoint = 0; dividingPoint <= size; dividingPoint++)
        {
            int possibleProfit = maxProfit[size - dividingPoint] + prices[dividingPoint];
            if (possibleProfit > maxProfit[size])
            {
                maxProfit[size] = possibleProfit;
                List<int> newSolution = new List<int>();
                newSolution.Add(dividingPoint);
                newSolution.AddRange(solutions[size - dividingPoint]);
                solutions[size] = newSolution;
            }
        }
    }

    return solutions[numSizes - 1];
}
*/