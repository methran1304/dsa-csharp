

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

    private static int CountChar(List<string> ls, int currentPos)
    {
        if (currentPos >= ls.Count)
        {
            return 0;
        }

        return ls[currentPos].Length + CountChar(ls, currentPos + 1);
    }

    private static List<int> OnlyEven(List<int> n, int currentPos)
    {
        if (currentPos >= n.Count) return [];

        List<int> subArray = new List<int>();

        if (n[currentPos] % 2 == 0) subArray.Add(n[currentPos]);

        return subArray.Concat(OnlyEven(n, currentPos + 1)).ToList();
    }

    private static int TriangularNumber(int n)
    {
        if (n <= 0) return 0;

        return n + TriangularNumber(n - 1);
    }

    private static int FirstX(string s, int currPos)
    {
        if (currPos >= s.Length) return -1;

        if (s[currPos] == 'x') return currPos;

        return FirstX(s, currPos + 1);
    }

    private static int MaxEl(List<int> x, int currPos)
    {
        if (currPos == x.Count - 1)
            return x[currPos];
            
        return Math.Max(x[currPos], MaxEl(x, currPos + 1));
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

        // List<int> arr = [4, 1, 2, 7]; // sum = 14        
        // Console.WriteLine(ArraySum(arr));

        // Console.WriteLine(CountChar(["ab", "c", "def", "ghij"], 0));
        // foreach (var el in OnlyEven([1, 1, 2, 3, 4, 5, 6, 7, 8], 0))
        // {
        //     Console.WriteLine(el);
        // }


        // Console.WriteLine(TriangularNumber(3));

        // Console.WriteLine(FirstX("abcdefghijklmnopqrstuvwxyz", 0));

        Console.WriteLine(MaxEl([1, 7, 2, 21, 0, -12], 0));
    }
}