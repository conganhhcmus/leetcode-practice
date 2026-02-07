public class Solution
{
    public int MinCost(int[] nums)
    {
        return DP(nums, 1, 0);
    }
    Dictionary<(int, int), int> memo = [];
    private int DP(int[] nums, int curr, int last)
    {
        int n = nums.Length;
        if (curr + 1 >= n) return Math.Max(nums[last], curr < n ? nums[curr] : 0);
        var key = (curr, last);
        if (memo.TryGetValue(key, out var value)) return value;
        int ans = Math.Max(nums[curr], nums[curr + 1]) + DP(nums, curr + 2, last);
        ans = Math.Min(ans, Math.Max(nums[curr], nums[last]) + DP(nums, curr + 2, curr + 1));
        ans = Math.Min(ans, Math.Max(nums[curr + 1], nums[last]) + DP(nums, curr + 2, curr));
        memo[key] = ans;
        return ans;
    }
}