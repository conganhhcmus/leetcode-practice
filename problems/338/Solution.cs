namespace Problem_338;

public class Solution
{
    public static void Execute()
    {
        int n = 5;
        var solution = new Solution();
        Console.WriteLine($"[{string.Join(",", solution.CountBits(n))}]");
    }
    public int[] CountBits(int n)
    {
        int[] result = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            result[i] = result[i >> 1] + (i & 1);
        }
        return result;
    }
}