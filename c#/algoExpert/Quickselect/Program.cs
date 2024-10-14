// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

Quickselect(new int[] { 8, 5, 2, 9, 7, 6, 3 }, 3);

static int Quickselect(int[] array, int k)
{
    int position = k - 1;
    return QuickselectMethod(array, 0, array.Length - 1 , position);
}

static int QuickselectMethod(int[] array, int startIdx, int endIdx, int position)
{
    while (true)
    {
        if (startIdx > endIdx) return -1;

        int pivotIdx = startIdx;
        int leftIdx = startIdx + 1;
        int rightIdx = endIdx;

        while (leftIdx <= rightIdx)
        {
            if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
            {
                swap(leftIdx, rightIdx, array);
            }

            if (array[leftIdx] <= array[pivotIdx]) leftIdx++;

            if (array[rightIdx] >= array[pivotIdx]) rightIdx--;
        }

        swap(pivotIdx, rightIdx, array);
        if (rightIdx == pivotIdx)
        {
            return array[rightIdx];
        }
        else if (rightIdx < position)
        {
            startIdx = rightIdx + 1;
        }
        else
        {
            endIdx = rightIdx - 1;
        }
    }
}

static void swap(int i, int j, int[] array)
{
    int temp = array[j];
    array[j] = array[i];
    array[i] = temp;
}