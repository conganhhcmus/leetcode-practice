public class Solution
{
    int INF = int.MaxValue / 2;
    public int MinRemovals(int[] nums, int target)
    {
        int mask = 0;
        foreach (int num in nums)
        {
            mask ^= num;
        }
        mask ^= target;
        int ans = DP(mask, 0, nums);
        if (ans >= INF) return -1;
        return ans;
    }

    Dictionary<(int, int), int> memo = [];

    int DP(int curr, int pos, int[] nums)
    {
        if (curr == 0) return 0;
        int n = nums.Length;
        if (pos >= n)
        {
            return INF;
        }
        var key = (curr, pos);
        if (memo.TryGetValue(key, out int cache)) return cache;

        return memo[key] = Math.Min(
            1 + DP(curr ^ nums[pos], pos + 1, nums),
            DP(curr, pos + 1, nums)
        );
    }
}