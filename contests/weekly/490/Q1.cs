public class Solution
{
    public int ScoreDifference(int[] nums)
    {
        int diff = 0;
        int sign = 1;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 1)
            {
                sign *= -1;
            }
            if ((i % 6) == 5)
            {
                sign *= -1;
            }
            diff += sign * nums[i];
        }

        return diff;
    }
}