public class Solution
{
    public int SmallestRangeII(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = nums[n - 1] - nums[0];
        for (int i = 1; i < n; i++)
        {
            // if choose i to mid, 0..i + k, i+1..n -k
            // min = nums[0] + k, nums[i] - k
            // max = nums[n-1] - k, nums[i - 1] + k
            int min = Math.Min(nums[0] + k, nums[i] - k);
            int max = Math.Max(nums[n - 1] - k, nums[i - 1] + k);
            if (ans > max - min) ans = max - min;
        }
        return ans;
    }
}
