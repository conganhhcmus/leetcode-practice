namespace Problem_5;

public class Solution
{
    public string LongestPalindrome(string s)
    {
        var res = new int[2];

        var dp = new bool[s.Length][];
        for (var i = 0; i < s.Length; i++)
        {
            dp[i] = new bool[s.Length];
            Array.Fill(dp[i], false);
            dp[i][i] = true;
        }
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i - 1] == s[i])
            {
                dp[i - 1][i] = true;
                res = [i - 1, i];
            }
        }

        for (var diff = 2; diff <= s.Length; diff++)
        {
            for (var i = 0; i < (s.Length - diff); i++)
            {
                var j = i + diff;
                if (s[i] == s[j] && dp[i + 1][j - 1])
                {
                    dp[i][j] = true;
                    res = [i, j];
                }
            }
        }
        Console.WriteLine($"[{res[0]},{res[1]}]");
        return s[res[0]..(res[1] + 1)];
    }
}