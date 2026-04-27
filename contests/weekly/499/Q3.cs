public class Solution
{
    public long MinOperations(int[] nums)
    {
        long cost = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            cost += Math.Max(0, nums[i - 1] - nums[i]);
        }
        return cost;
    }
}
