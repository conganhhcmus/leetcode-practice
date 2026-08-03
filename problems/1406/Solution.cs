public class Solution
{
    public string StoneGameIII(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int INF = 1 << 30;
        Dictionary<(int, int), int> memo = [];
        int ans = DP(0, n - 1);
        if (ans > 0) return "Alice";
        if (ans < 0) return "Bob";
        return "Tie";

        int DP(int l, int r)
        {
            if (l > r) return 0;
            if (l == r) return stoneValue[l];
            var key = (l, r);
            if (memo.TryGetValue(key, out int cache)) return cache;
            int ans = -INF;
            ans = Math.Max(ans, stoneValue[l] - DP(l + 1, r));
            if (l + 1 <= r) ans = Math.Max(ans, stoneValue[l] + stoneValue[l + 1] - DP(l + 2, r));
            if (l + 2 <= r) ans = Math.Max(ans, stoneValue[l] + stoneValue[l + 1] + stoneValue[l + 2] - DP(l + 3, r));
            return memo[key] = ans;
        }
    }
}
