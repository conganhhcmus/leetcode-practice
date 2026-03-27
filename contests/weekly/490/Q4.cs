public class Solution
{
    public int CountSequences(int[] nums, long k)
    {
        return DP(0, 1, 1, nums, k);
    }

    Dictionary<(int, long, long), int> memo = [];

    int DP(int pos, long mul, long div, int[] nums, long k)
    {
        int n = nums.Length;
        if (pos >= n)
        {
            if (mul == k * div) return 1;
            return 0;
        }
        var key = (pos, mul, div);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = 0;
        // skip
        ans += DP(pos + 1, mul, div, nums, k);
        // mul
        ans += DP(pos + 1, mul * nums[pos], div, nums, k);
        // div
        ans += DP(pos + 1, mul, div * nums[pos], nums, k);

        return memo[key] = ans;
    }
}