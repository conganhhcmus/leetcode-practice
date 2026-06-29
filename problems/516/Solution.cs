public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        int n = s.Length;
        int[,] memo = new int[n, n];
        return DP(0, n - 1);

        int DP(int i, int j)
        {
            if (i > j) return 0;
            if (i == j) return 1;
            if (memo[i, j] != 0) return memo[i, j];
            int ans = Math.Max(DP(i + 1, j), DP(i, j - 1));
            if (s[i] == s[j]) ans = Math.Max(ans, 2 + DP(i + 1, j - 1));
            return memo[i, j] = ans;
        }
    }
}
