public class Solution
{
    public int MaxSubArrayLen(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<long, int> map = [];
        int ans = 0;
        long prefixSum = 0;
        map[0] = -1;
        for (int i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            map.TryAdd(prefixSum, i);
            ans = Math.Max(ans, i - map.GetValueOrDefault(prefixSum - k, i));
        }

        return ans;
    }
}