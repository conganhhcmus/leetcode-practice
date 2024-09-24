namespace Practice_2028;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] rolls = [3, 2, 4, 3];
        int mean = 4;
        int n = 2;

        Console.WriteLine($"[{string.Join(",", solution.MissingRolls(rolls, mean, n))}]");
    }

    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int sum = mean * (rolls.Length + n) - rolls.Sum();
        if (6 * n < sum || sum < n) return [];

        int div = sum / n;
        int mod = sum % n;
        var res = new int[n];
        Array.Fill(res, div + 1, 0, mod);
        Array.Fill(res, div, mod, n - mod);

        return res;
    }
}