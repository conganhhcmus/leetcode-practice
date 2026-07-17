public class Solution
{
    public long MaxProduct(int[] nums)
    {
        int n = nums.Length;
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = Math.Abs(nums[i]);
        }
        Array.Sort(a);
        return 1L * a[^1] * a[^2] * 100_000;
    }
}
