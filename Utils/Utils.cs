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
}