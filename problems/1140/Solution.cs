public class Solution
{
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;
        // dp[i] = diff with curr turn from 0..i
        // dp[i + X] = Max take - dp[i]
        // A - B = diff
        // A + B = total
        // A = (total + diff) / 2
        Dictionary<(int, int), int> memo = [];
        int diff = Dp(0, 1);
        int total = 0;
        for (int i = 0; i < n; i++)
        {
            total += piles[i];
        }
        return (total + diff) / 2;


        int Dp(int p, int m)
        {
            if (p >= n) return 0;
            var key = (p, m);
            if (memo.TryGetValue(key, out int cache)) return cache;
            int ans = int.MinValue;
            int sum = 0;
            for (int x = 0; x < 2 * m && p + x < n; x++)
            {
                sum += piles[p + x];
                ans = Math.Max(ans, sum - Dp(p + x + 1, Math.Max(m, x + 1)));
            }
            return memo[key] = ans; ;
        }
    }
}
