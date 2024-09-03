// See https://aka.ms/new-console-template for more information

/*
 * You're given two positive integers representing the width and height of a grid-shaped, rectangular graph. Write
 * a function that returns the number of ways to reach the bottom right corner of the graph when starting at the
 * top left corner. Each move you take must either go down or right. In other words, you can never move up or left
 * in the graph.
 *
 * For example, given the graph illustrated below, with width = 2 and height = 3, there are three ways to reach the
 * bottom right corner when starting at the top left corner:
 *   _ _
 *  |_|_|
 *  |_|_|
 *  |_|_|
 *
 * 1 - Down, Down, Right
 * 2 - Right, Down, Down
 * 3 - Down, Right, Down
 *
 * Note: you may assume that width * height >= 2. In other words, the graph will never be a 1x1 grid.
 *
 * Sample Input: width = 4; height = 3;
 */

Console.WriteLine("Hello, World!");

int width = 4;
int height = 3;

var result = NumberOfWaysToTraverseGraphMethod(width, height);

Console.WriteLine(result);

// Time O (2^(n + m)) | Space O(n + m)
static int NumberOfWaysToTraverseGraphMethod(int width, int height)
{
    if (width == 1 || height == 1) return 1;
    
    return NumberOfWaysToTraverseGraphMethod(width - 1, height) + NumberOfWaysToTraverseGraphMethod(width, height - 1);
}

static int NumberOfWaysToTraverseGraphMethod2(int width, int height)
{
    int[,] numberOfWays = new int[height + 1, width + 1];
    for (int widthIdx = 1; widthIdx < width + 1; widthIdx++)
    {
        for (int heightIdx = 1; heightIdx < height + 1; heightIdx++)
        {
            if (widthIdx == 1 || heightIdx == 1)
            {
                numberOfWays[heightIdx, widthIdx] = 1;
            }
            else
            {
                int waysLeft = numberOfWays[heightIdx, widthIdx - 1];
                int waysUp = numberOfWays[heightIdx - 1, widthIdx];
                numberOfWays[heightIdx, widthIdx] = waysLeft + waysUp;
            }
        }
    }
    return numberOfWays[height, width];
}

static int NumberOfWaysToTraverseGraphMethod3(int width, int height)
{
    int xDistanceToCorner = width - 1;
    int yDistanceToCorner = height - 1;

    int numerator = Factorial(xDistanceToCorner + yDistanceToCorner);
    int denominator = Factorial(xDistanceToCorner) * Factorial(yDistanceToCorner);

    return numerator / denominator;
}

static int Factorial(int num)
{
    int result = 1;

    for (int n = 2; n < num + 1; n++)
    {
        result *= num;
    }
    
    return result;
}