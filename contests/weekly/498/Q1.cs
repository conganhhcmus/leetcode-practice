public class Solution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        int n = nums.Length;
        int[] suff = new int[n];
        suff[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suff[i] = Math.Min(suff[i + 1], nums[i]);
        }
        int max = nums[0];
        for (int i = 0; i < n; i++)
        {
            if (max < nums[i]) max = nums[i];
            if (max - suff[i] <= k) return i;
        }
        return -1;
    }
}
