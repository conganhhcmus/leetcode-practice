public class Solution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long maxSum = 0, sum = 0;
        HashSet<int> hashSet = [];
        int n = nums.Length;
        int l = 0, r = 0;

        while (r < n)
        {
            if (hashSet.Count >= k)
            {
                hashSet.Remove(nums[l]);
                sum -= nums[l];
                l++;
            }

            while (!hashSet.Add(nums[r]))
            {
                hashSet.Remove(nums[l]);
                sum -= nums[l];
                l++;
            }
            sum += nums[r];
            if (hashSet.Count == k)
            {
                maxSum = Math.Max(maxSum, sum);
            }

            r++;
        }

        return maxSum;
    }
}