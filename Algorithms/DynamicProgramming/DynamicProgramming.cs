using System.Runtime.Intrinsics.Arm;

namespace Algorithm;

public class DPPlayground
{
    private static int counter = 0;
    public long TopDownFib(int n, Dictionary<int, long> memo)
    {
        // Console.WriteLine($"A: {counter++}");

        if (n == 0 || n == 1) return n;

        if (!memo.ContainsKey(n))
            memo[n] = TopDownFib(n - 1, memo) + TopDownFib(n - 2, memo);

        return memo[n];
    }

    public long BottomUpFib(int n)
    {
        if (n == 0) return 0;

        int a = 0;
        int b = 1;

        for (int i = 2; i < n; i++)
        {
            int temp = a;
            a = b;
            b = temp + a;
        }

        return a + b;
    }

    public int SumHundred(List<int> list, int currentSum, int currentPos)
    {
        if (currentPos >= list.Count)
            return currentSum;

        if (list[currentPos] + currentSum > 100)
            return SumHundred(list, currentSum, currentPos + 1);
        else
            return SumHundred(list, list[currentPos] + currentSum, currentPos + 1);
    }

    public int SumHundredMemo(List<int> list, int currentSum, int currentPos, Dictionary<int, int> memo)
    {
        if (currentPos >= list.Count) return currentSum;

        bool includeSum = currentSum + list[currentPos] <= 100;

        if (!memo.ContainsKey(currentPos))
        {
            memo[currentPos] = SumHundredMemo(
                list,
                includeSum ? currentSum + list[currentPos] : currentSum,
                currentPos + 1,
                memo
            );
        }

        return memo[currentPos];
    }

    public int SumHundredTabulation(List<int> list)
    {
        int s = 0;

        for (int i = 0; i < list.Count; i++)
        {
            if (s + list[i] <= 100) s += list[i];
        }

        return s;
    }

    public int Golomb(int n)
    {
        if (n == 1) return n;
        return 1 + Golomb(n - Golomb(n - 1));
    }

    public int GolombMemo(int n, Dictionary<int, int> memo)
    {
        if (n == 1) return n;

        if (memo.ContainsKey(n)) return memo[n];

        if (!memo.ContainsKey(n - 1))
            memo[n - 1] = GolombMemo(n - 1, memo);

        memo[n] = 1 + GolombMemo(n - memo[n - 1], memo);

        return memo[n];
    }
}

public static class DynamicProgramming
{
    public static void Begin()
    {
        // 242784
        DPPlayground dPPlayground = new();
        // Console.WriteLine(dPPlayground.BottomUpFib(6));
        // Console.WriteLine(dPPlayground.SumHundredMemo([20, 40, 10, 20, 10], 0, 0, []));

        Console.WriteLine(dPPlayground.GolombMemo(10, []));
    }
}
