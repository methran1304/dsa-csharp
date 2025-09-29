using System.Xml;

namespace Algorithms;

public static class Recursion
{
    private static int Sum(int n)
    {
        if (n <= 1) return n;
        return n + Sum(n - 1);
    }

    private static int ArraySum(List<int> arr)
    {
        if (arr.Count == 0)
            return 0;

        if (arr.Count == 1)
            return arr[0];

        return arr[0] + ArraySum(arr[1..]);
    }

    private static int StackTraceVisualisation(int n)
    {
        if (n <= 1)
            throw new Exception("Reached Base Case");

        return n + StackTraceVisualisation(n - 1);
    }

    public static void Begin()
    {
        // int n = 5;
        // try
        // {
        //     int result = StackTraceVisualisation(n);
        //     Console.WriteLine(result);
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     Console.WriteLine(ex.StackTrace);
        // }

        List<int> arr = [4, 1, 2, 7]; // sum = 14        
        Console.WriteLine(ArraySum(arr));
    }
}
