/*
 * Water area
 *
 * You're given an array of non-negative integers where each non-zero integer
 * represents the height of a pillar of width 1. Imagine water being poured over
 * all the pillars; write a function that returns the surface area of the water
 * trapped between the pillars viewed from the front. Note that spilled water
 * shold be ignored.
 *
 * You can refer to the first three minutes of this question's video explanation for a
 * visual example.
 * 
 */
var heights = new int[] { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 };
var result = WaterArea(heights);

static int WaterArea(int[] heights)
{
    int[] maxes = new int[heights.Length];
    int leftMax = 0;

    for (int i = 0; i < heights.Length; i++)
    {
        int height = heights[i];
        maxes[i] = leftMax;
        leftMax = Math.Max(leftMax, height);
    }

    int rightMax = 0;
    for (int i = heights.Length - 1; i >= 0; i--)
    {
        int height = heights[i];
        int minHeight = Math.Min(rightMax, maxes[i]);
        if (height < minHeight)
        {
            maxes[i] = minHeight - height;
        }
        else
        {
            maxes[i] = 0;
        }

        rightMax = Math.Max(rightMax, height);
    }

    int total = 0;
    for (int i = 0; i < heights.Length; i++)
    {
        total += maxes[i];
    }

    return total;
}