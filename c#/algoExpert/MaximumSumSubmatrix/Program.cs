/*
 * Maximum Sum Submatrix
 *
 * You're given a two-dimensional array (a matrix) of potentially unequal height
 * and width that's filled with integers. You're also given a positive integer size.
 * Write a function that returns the maximum sum that can be generated from a
 * submatrix with dimensions size * sizes.
 *
 * For example, consider the following matrix:
 *
 * [
 *   [2, 4],
 *   [5, 6],
 *   [-3, 2]
 * ]
 *
 * If size = 2, then the 2x2 submatrices to consider are:
 *
 * [2, 4]
 * [5, 6]
 * -------
 * [5, 6]
 * [-3, 2]
 *
 * The sum of the elements in the first submatrix is 17, and the sum of the
 * elements in the second submatrix is 10. In this example, your function should
 * return 17.
 */

int[,] matrix = new int[,] { { 5, 3, -1, 5 }, { -7, 3, 7, 4 }, { 12, 8, 0, 0 }, { 1, -8, -8, 2 } };
int size = 2;


var result = MaximumSumSubmatrix(matrix, size);

static int MaximumSumSubmatrix(int[,] matrix, int size)
{
    int[,] sums = createSumMatrix(matrix);
    int maxSubMatrixSum = Int32.MinValue;

    for (int row = size - 1; row < matrix.GetLength(0); row++)
    {
        for (int col = size - 1; col < matrix.GetLength(1); col++)
        {
            int total = sums[row, col];
            bool touchesTopBorder = (row - size < 0);
            if (!touchesTopBorder)
            {
                total -= sums[row - size, col];
            }

            bool touchesLeftBorder = (col - size < 0);
            if (!touchesLeftBorder)
            {
                total -= sums[row, col - size];
            }

            bool touchesTopOrLeftBorder = (touchesTopBorder || touchesLeftBorder);
            if (!touchesTopOrLeftBorder)
            {
                total += sums[row - size, col - size];
            }

            maxSubMatrixSum = Math.Max(maxSubMatrixSum, total);
        }
    }
    return maxSubMatrixSum;
}

static int[,] createSumMatrix(int[,] matrix)
{
    int[,] sums = new int[matrix.GetLength(0), matrix.GetLength(1)];
    sums[0, 0] = matrix[0, 0];

    // Fill the first row.
    for (int idx = 1; idx < matrix.GetLength(1); idx++)
    {
        sums[0, idx] = sums[0, idx - 1] + matrix[0, idx];
    }
    
    // Fill the first column
    for (int idx = 1; idx < matrix.GetLength(0); idx++)
    {
        sums[idx, 0] = sums[idx - 1, 0] + matrix[idx, 0];
    }
    
    // Fill in the rest of the matrix
    for (int row = 1; row < matrix.GetLength(0); row++)
    {
        for ( int col = 1; col < matrix.GetLength(1); col++)
        {
            sums[row, col] = sums[row - 1, col] + sums[row, col - 1] -
                sums[row - 1, col - 1] + matrix[row, col];
        }
    }

    return sums;
}