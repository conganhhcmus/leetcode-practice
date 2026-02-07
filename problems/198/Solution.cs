public class Solution
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] f = new int[n + 1];
        f[0] = 0;
        f[1] = nums[0];
        for (int i = 2; i <= n; i++)
        {
            f[i] = Math.Max(f[i - 1], f[i - 2] + nums[i - 1]);
        }
        return f[n];
    }
}