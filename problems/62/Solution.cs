namespace Problem_62;

public class Solution
{
    public static void Execute()
    {
        int m = 3;
        int n = 7;
        var solution = new Solution();
        Console.WriteLine(solution.UniquePaths(m, n));
    }
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n];
        dp[0] = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] = dp[j - 1] + dp[j];
            }
        }

        return dp[n - 1];
    }
}