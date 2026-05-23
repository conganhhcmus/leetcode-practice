public class Solution
{
    public bool Check(int[] nums)
    {
        int diff = 0;
        int n = nums.Length;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] < nums[i - 1]) diff++;
        }
        if (nums[n - 1] > nums[0]) diff++;
        return diff < 2;
    }
}
