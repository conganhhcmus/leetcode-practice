public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int n = s.Length, m = t.Length;
        int[,] memo = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                memo[i, j] = -1;
            }
        }
        return DP(0, 0);

        int DP(int p1, int p2)
        {
            if (p2 >= m) return 1;
            if (p1 >= n) return 0;
            if (memo[p1, p2] != -1) return memo[p1, p2];
            int ans = 0;
            if (s[p1] == t[p2])
            {
                ans += DP(p1 + 1, p2 + 1);
            }
            ans += DP(p1 + 1, p2);

            return memo[p1, p2] = ans;
        }
    }
}
