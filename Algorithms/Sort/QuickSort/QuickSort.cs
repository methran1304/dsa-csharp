namespace Algorithms;

using Utils;

public static class QuickSort
{
    private static void QSort(List<int> arr, int low, int high)
    { 
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            // recursively partition left and right sub arrays (excluding pivot)
            QSort(arr, low, pivotIndex - 1);
            QSort(arr, pivotIndex + 1, high);
        }
    }

    // uses lomuto partitioning (with in-place swapping)
    private static int Partition(List<int> arr, int low, int high)
    {
        int pivotIndex = arr[high];
        int i = -1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= arr[pivotIndex])
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return i + 1;
    }

    private static void Swap(List<int> arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    public static void Begin()
    {
        List<int> arr = [2, 1, 3, 5, 4];
        Utils.PrintArray(arr);
        QSort(arr, 0, arr.Count - 1);
        Utils.PrintArray(arr);
    }
}
