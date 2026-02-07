public class Solution
{
    public int MaximizeSum(int[] nums, int k)
    {
        int n = nums.Length;
        int max = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (max < nums[i]) max = nums[i];
        }
        // [max, max + k -1]
        return k * (2 * max + k - 1) / 2;
    }
}