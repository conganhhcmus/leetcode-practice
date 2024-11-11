namespace Problem_72;
using Helpers.Array;
public class Solution
{
    public static void Execute()
    {
        string word1 = "horse";
        string word2 = "ros";
        var solution = new Solution();
        Console.WriteLine(solution.MinDistance(word1, word2));
    }
    public int MinDistance(string word1, string word2)
    {
        int n = word1.Length;
        int m = word2.Length;
        if (n == 0) return m;
        if (m == 0) return n;
        int[,] dp = new int[n + 1, m + 1];
        for (int i = 0; i <= n; i++) dp[i, 0] = i;
        for (int j = 0; j <= m; j++) dp[0, j] = j;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (word1[i - 1] == word2[j - 1]) dp[i, j] = dp[i - 1, j - 1];
                else dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
            }
        }
        ArrayHelper.Print2DArray(dp);
        return dp[n, m];
    }
}