public class Solution
{
    public int SmallestRangeI(int[] nums, int k)
    {
        int n = nums.Length;
        int min = nums[0], max = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (min > nums[i]) min = nums[i];
            if (max < nums[i]) max = nums[i];
        }
        int diff = max - min;
        if (diff <= 2 * k) return 0;
        return diff - 2 * k;
    }
}
