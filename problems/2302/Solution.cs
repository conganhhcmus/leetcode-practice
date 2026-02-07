public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        long ret = 0;
        int left = 0;
        for (int right = 0; right < n; right++)
        {
            long score = (prefixSum[right + 1] - prefixSum[left]) * (right - left + 1);
            while (left <= right && score >= k)
            {
                left++;
                score = (prefixSum[right + 1] - prefixSum[left]) * (right - left + 1);
            }
            ret += right - left + 1;
        }
        return ret;
    }
}