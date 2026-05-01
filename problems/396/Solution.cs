public class Solution
{
    public int MaxRotateFunction(int[] nums)
    {
        int n = nums.Length;
        int tot = 0;
        int f = 0;
        for (int i = 0; i < n; i++)
        {
            tot += nums[i];
            f += i * nums[i];
        }
        int ans = f;
        for (int i = n - 1; i > 0; i--)
        {
            // f(1) - f(0) = tot - n * [last]
            // f(1) = f(0) + tot - n * [last]
            f += tot - (n * nums[i]);
            ans = Math.Max(ans, f);
        }
        return ans;
    }
}
