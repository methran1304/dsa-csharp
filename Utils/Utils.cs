namespace Utils;

public static class Utils
{
    public static void PrintArray(List<int> arr)
    {
        foreach (int elem in arr)
        {
            Console.Write($"{elem} ");
        }

        Console.Write('\n');
    }

    public static void Swap(int l, int r)
    {
        (l, r) = (r, l);
    }
}