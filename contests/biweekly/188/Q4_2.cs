public class Solution
{
    public int MinMaxWaitingTime(int[] demand, int[] fuel)
    {
        int n = demand.Length;
        Dictionary<(int, int, int, int, int), int[]> memo = [];
        int[] ans = Dp(0, fuel[0], fuel[1], 0, 0);
        if (ans[0] == 0) return -1;
        return ans[1];
        int[] Dp(int pos, int f0, int f1, int w0, int w1)
        {
            int res0 = 0, res1 = 0, c0 = 0, c1 = 0;
            if (pos >= n) return [0, 0];
            var key = (pos, f0, f1, w0, w1);
            if (memo.TryGetValue(key, out int[] cache)) return cache;
            int d = demand[pos];
            if (f0 >= d)
            {
                int[] p = Dp(pos + 1, f0 - d, f1, d, Math.Max(0, w1 - w0));
                c0 = p[0] + 1;
                res0 = Math.Max(p[1], w0);
            }
            if (f1 >= d)
            {
                int[] p = Dp(pos + 1, f0, f1 - d, Math.Max(0, w0 - w1), d);
                c1 = p[0] + 1;
                res1 = Math.Max(p[1], w1);
            }

            int[] ans;
            if (c0 < c1) ans = [c1, res1];
            else if (c0 > c1) ans = [c0, res0];
            else ans = [c0, Math.Min(res0, res1)];
            return memo[key] = ans;
        }
    }
}
