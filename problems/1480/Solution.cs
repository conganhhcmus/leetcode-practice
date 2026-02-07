public class Solution
{
    public int[] RunningSum(int[] nums)
    {
        int n = nums.Length;
        int[] ret = new int[n];
        ret[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            ret[i] = ret[i - 1] + nums[i];
        }

        return ret;
    }
}