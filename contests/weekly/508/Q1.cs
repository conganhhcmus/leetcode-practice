public class Solution
{
    public long MaxSum(int[] nums, int k, int mul)
    {
        Array.Sort(nums, (a, b) => b - a);
        long ans = 0L;
        for (int i = 0; i < k; i++)
        {
            ans += Math.Max(nums[i], 1L * nums[i] * mul);
            mul--;
        }
        return ans;
    }
}
