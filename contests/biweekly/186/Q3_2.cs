public class Solution
{
    public int MinOperations(string s1, string s2)
    {
        int n = s1.Length;
        int INF = 1 << 30;
        int?[,] memo = new int?[n + 1, 2];
        int ans = Dp(0, s1[0] - '0');
        return ans >= INF ? -1 : ans;

        int Dp(int i, int cur)
        {
            if (i == n) return cur == 0 ? 0 : INF;
            if (memo[i, cur].HasValue) return memo[i, cur].Value;
            int ans = INF;
            int t = s2[i] - '0';
            // make 0 -> 1, 0 -> 0, 1 -> 1
            if (cur <= t)
            {
                int cost = t - cur;
                int next = (i + 1 < n) ? s1[i + 1] - '0' : 0;
                ans = Math.Min(ans, cost + Dp(i + 1, next));
            }
            // make 11 -> 00
            if (i + 1 < n)
            {
                int next = s1[i + 1] - '0';
                int cost = 1 + (1 - cur) + (1 - next) + t;
                ans = Math.Min(ans, cost + Dp(i + 1, 0));
            }
            memo[i, cur] = ans;
            return ans;
        }
    }
}
