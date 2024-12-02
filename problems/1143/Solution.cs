namespace Problem_1143;
public class Solution
{
    public static void Execute()
    {
        string text1 = "bsbininm";
        string text2 = "jmjkbkjkv";
        var solution = new Solution();
        Console.WriteLine(solution.LongestCommonSubsequence(text1, text2));
    }

    public int LongestCommonSubsequence(string text1, string text2)
    {
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <= text2.Length; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[text1.Length, text2.Length];
    }

    public int LongestCommonSubsequence_1D(string text1, string text2)
    {
        int[] dp = new int[text2.Length + 1];
        for (int i = 1; i <= text1.Length; i++)
        {
            int prev = 0;
            for (int j = 1; j <= text2.Length; j++)
            {
                int temp = dp[j];
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[j] = prev + 1;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }
                prev = temp;
            }
        }
        return dp[text2.Length];
    }
}