namespace Problem_2707;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();

        string s = "dwmodizxvvbosxxw";
        string[] dictionary = ["ox", "lb", "diz", "gu", "v", "ksv", "o", "nuq", "r", "txhe", "e", "wmo", "cehy", "tskz", "ds", "kzbu"];
        // string s = "leetscode";
        // string[] dictionary = ["leet", "code", "leetcode"];
        Console.WriteLine(solution.MinExtraChar(s, dictionary));
    }
    public int MinExtraChar(string s, string[] dictionary)
    {
        int[] dp = new int[s.Length + 1];
        HashSet<string> set = [.. dictionary];

        for (int i = 1; i <= s.Length; i++)
        {
            dp[i] = dp[i - 1] + 1;

            for (int len = 1; len <= i; len++)
            {
                var curr = s[(i - len)..i];

                if (set.Contains(curr))
                {
                    dp[i] = int.Min(dp[i], dp[i - len]);
                }
            }
        }

        return dp[s.Length];
    }
}