public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        int count = 0;
        Dictionary<long, int> map = [];
        map[0] = 1;
        long prefixSum = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            count += map.GetValueOrDefault(prefixSum - k, 0);
            map[prefixSum] = map.GetValueOrDefault(prefixSum, 0) + 1;
        }

        return count;
    }
}