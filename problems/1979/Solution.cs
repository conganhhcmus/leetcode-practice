public class Solution
{
    public int FindGCD(int[] nums)
    {
        int min = nums[0], max = nums[0];
        foreach (int num in nums)
        {
            if (min > num) min = num;
            if (max < num) max = num;
        }
        while (min > 0)
        {
            (min, max) = (max % min, min);
        }
        return max;
    }
}
