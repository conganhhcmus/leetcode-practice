public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        int n = nums.Length;
        long[] arr = new long[n];
        for (int i = 0; i < n; i++) arr[i] = 1L * nums[i] * nums[i];
        Array.Sort(arr);
        long ans = 0;
        for (int i = 0; i < n / 2; i++)
        {
            ans -= arr[i];
        }
        for (int i = n / 2; i < n; i++)
        {
            ans += arr[i];
        }
        return ans;
    }
}
