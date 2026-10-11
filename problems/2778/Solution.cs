public class Solution
{
    public int SumOfSquares(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (n % (i + 1) == 0) ans += nums[i] * nums[i];
        }
        return ans;
    }
}
