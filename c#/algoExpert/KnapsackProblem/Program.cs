/*
 * Knapsack Problem
 *
 * You're given an array of arrays where each subarray holds two integer values
 * and represents an item; the first integer is the item's value, and the second
 * integer is the item's weight. You're also given an integer representing the
 * maximum capacity of a knapsack that you have.
 *
 * Your goal is to fit items in your knapsack without having the sum of their
 * weights exceed the knapsack's capacity, all the while maximizing their combined
 * value. Note that you only have one of each item at your disposal.
 *
 * Write a function that returns the maximized combined value of the items that
 * you should pick as well as an array of the indices of each item picked.
 *
 * If there are multiple combinations of items that maximize the total value in the
 * knapsack, your function can return any of them.
 * .
 * 
 */

var itemsInput = new int[,] { { 1, 2 }, {4, 3}, {5, 6}, {6, 7} };
var capacityInput = 10;

/*         00 01 02 03 04 05 06 07 08 09 10
 * [ , ]   0  0  0  0  0  0  0  0  0  0  0
 * [1, 2]  0  0  1  1  1  1  1  1  1  1  1
 * [4, 3]  0  0  1  4  4  5  5  5  5  5  5
 * [5, 6]  0  0  1  4  4  5  5  5  6  9  9
 * [6, 7]  0  0  1  4  4  5  5  6  6  9  10
 */

var result = KnapsackProblem(itemsInput, capacityInput);

// O(nc) time | O(nc) space
static List<List<int>> KnapsackProblem(int[,] items, int capacity)
{
    int[,] knapsackValues = new int[items.GetLength(0) + 1, capacity + 1];
    for (int i = 1; i < items.GetLength(0) + 1; i++)
    {
        int currentWeight = items[i - 1, 1];
        int currentValue = items[i - 1, 0];
        for (int c = 0; c < capacity + 1; c++)
        {
            if (currentWeight > c)
            {
                knapsackValues[i, c] = knapsackValues[i - 1, c];
            }
            else
            {
                knapsackValues[i, c] = Math.Max(knapsackValues[i - 1, c],
                    knapsackValues[i - 1, c - currentWeight] + currentValue);
            }
        }
    }

    var result = getKnapsackItems(knapsackValues, items, knapsackValues[items.GetLength(0), capacity]);

    return result;
}

static List<List<int>> getKnapsackItems(int[,] knapsackValues, int[,] items, int weight)
{
    List<List<int>> sequence = new List<List<int>>();
    List<int> totalWeight = new List<int>();
    totalWeight.Add(weight);
    sequence.Add(totalWeight);
    sequence.Add(new List<int>());
    int i = knapsackValues.GetLength(0) - 1;
    int c = knapsackValues.GetLength(1) - 1;
    while (i > 0)
    {
        if (knapsackValues[i, c] == knapsackValues[i - 1, c])
        {
            i--;
        }
        else
        {
            sequence[1].Insert(0, i - 1);
            c -= items[i - 1, 1];
            i--;
        }

        if (c == 0)
            break;
    }

    return sequence;
}