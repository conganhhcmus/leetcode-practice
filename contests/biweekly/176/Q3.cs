public class Solution
{
    public long Rob(int[] nums, int[] colors)
    {
        return DP(0, 0, nums, colors);
    }

    Dictionary<(int, int), long> memo = [];

    long DP(int p, int c, int[] nums, int[] colors)
    {
        int n = nums.Length;
        if (p >= n) return 0;
        var key = (p, c);
        if (memo.TryGetValue(key, out long cache)) return cache;
        long ans = 0;
        ans = Math.Max(ans, DP(p + 1, 0, nums, colors));
        if (colors[p] != c)
        {
            c = colors[p];
            ans = Math.Max(ans, nums[p] + DP(p + 1, c, nums, colors));
        }

        return memo[key] = ans;
    }
}