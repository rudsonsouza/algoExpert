// See https://aka.ms/new-console-template for more information

/*
 * River Sizes
 *
 * You're given a two-dimensional array(a matrix) of potentially unequal height and width containing
 * only 0s and 1s. Each 0 represents land, and each 1 represents part of a river. A river
 * consists of any number of 1s that are either horizontally or vertically adjacent (but not diagonally
 * adjacent). The number of adjacent 1s forming a river determine its size.
 *
 * Note that a river can twist. In other words, it doesn't have to be a straight vertical line or a straight
 * horizontal line; it can be L-shaped, for example.
 *
 * Write a function that returns an array of the sizes of all rivers represented in the input matrix. The
 * sizes don't need to be in any particular order.
 */

Console.WriteLine("Hello, World!");

int[,] input =
{
    { 1, 0, 0, 1, 0 },
    { 1, 0, 1, 0, 0 },
    { 0, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1 },
    { 1, 0, 1, 1, 0 }
};

var result = RiverSizes(input);

// O(wh) time | O(wh) space
static List<int> RiverSizes(int[,] matrix)
{
    List<int> sizes = new List<int>();
    bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
    
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (visited[i, j] == true) continue;

            traverseNode(i, j, matrix, visited, sizes);
        }
    }

    return sizes;
}

static void traverseNode(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
{
    
}