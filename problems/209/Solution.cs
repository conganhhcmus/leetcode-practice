public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int n = nums.Length;
        int min = n + 1;
        long sum = 0;
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            sum += nums[r];
            while (sum >= target)
            {
                min = Math.Min(min, r - l + 1);
                sum -= nums[l];
                l++;
            }
        }
        return min == n + 1 ? 0 : min;
    }
}