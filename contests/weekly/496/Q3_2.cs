public class Solution
{
    public long MinIncrease(int[] nums)
    {
        int n = nums.Length;
        if (n < 3) return 0;
        long Cost(int i)
        {
            return Math.Max(0L, Math.Max(nums[i - 1], nums[i + 1]) + 1L - nums[i]);
        }
        if (n % 2 != 0)
        {
            long ans = 0;
            for (int i = 1; i < n - 1; i += 2)
            {
                ans += Cost(i);
            }
            return ans;
        }
        else
        {
            long sum = 0;
            int k = (n - 2) / 2;
            for (int i = 0; i < k; i++)
            {
                sum += Cost(2 * i + 2);
            }
            long ans = sum;
            for (int i = 0; i < k; i++)
            {
                sum += Cost(2 * i + 1) - Cost(2 * i + 2);
                ans = Math.Min(ans, sum);
            }
            return ans;
        }
    }
}