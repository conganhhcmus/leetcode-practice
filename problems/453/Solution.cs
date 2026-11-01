public class Solution
{
    public int MinMoves(int[] nums)
    {
        int n = nums.Length;
        int min = nums[0];
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            if (min > nums[i]) min = nums[i];
        }

        return (int)(sum - n * min);
    }
}