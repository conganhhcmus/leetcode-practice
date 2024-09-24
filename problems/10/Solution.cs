namespace Problem_10;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s = "aa";
        string p = "a*";
        Console.WriteLine(solution.IsMatch(s, p));
    }

    public bool IsMatch(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;

        for (int i = 1; i < dp.GetLength(1); i++)
        {
            if (p[i - 1] == '*')
            {
                dp[0, i] = dp[0, i - 2];

            }
        }

        for (int i = 1; i < dp.GetLength(0); i++)
        {
            for (int j = 1; j < dp.GetLength(1); j++)
            {
                if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 2];
                    if (s[i - 1] == p[j - 2] || p[j - 2] == '.')
                    {
                        dp[i, j] = dp[i, j] || dp[i - 1, j];
                    }
                }
                else
                {
                    dp[i, j] = false;
                }
            }
        }

        return dp[s.Length, p.Length];
    }

    public bool IsMatch2(string s, string p)
    {
        if (string.IsNullOrEmpty(p)) return string.IsNullOrEmpty(s);

        bool firstMatch = !string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.');

        if (p.Length >= 2 && p[1] == '*')
        {
            return IsMatch(s, p[2..])
            || (firstMatch && IsMatch(s[1..], p));
        }
        else
        {
            return firstMatch && IsMatch(s[1..], p[1..]);
        }
    }
}