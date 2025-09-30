namespace Algorithms;
using Utils;

public static class ElementarySort
{
    private static void BubbleSort(List<int> arr)
    {
        int n = arr.Count;

        for (int i = 0; i < n; i++) // iterate n times
        {
            bool madeSwaps = false;

            for (int j = 0; j < n - 1 - i; j++) // iterate from first element to (n - 1 - i)th element
            {
                if (arr[j] > arr[j + 1]) // check adjacent elements and swap if the first element > second element
                {
                    madeSwaps = true;
                    (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                }
            }

            if (!madeSwaps)
                break; // array is already sorted
        }
    }

    private static void SelectionSort(List<int> arr)
    {
        int i = 0, n = arr.Count;
        while (i < n)
        {
            int minIndex = GetMinIndex(arr, i, n);
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
            i++;
        }
    }

    private static void InsertionSort(List<int> arr)
    {
        int n = arr.Count, i = 1;
        while (i < n)
        {
            int j = i;

            while (j > 0 && arr[j - 1] > arr[j])
            {
                (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                j--;
            }

            i++;
        }
    }

    private static int GetMinIndex(List<int> arr, int s, int e)
    {
        int minIndex = s;
        for (int i = s; i < e; i++)
        {
            if (arr[i] < arr[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static void Begin()
    {
        List<int> arr = [2, 4, 5, 1, 3];


        Utils.PrintArray(arr);
        // BubbleSort(arr);
        // SelectionSort(arr);
        InsertionSort(arr);
        Utils.PrintArray(arr);
    }
}
