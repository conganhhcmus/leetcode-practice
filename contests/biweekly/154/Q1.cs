public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int ret = 0;
        foreach (int num in nums) ret = (ret + num) % k;
        return ret;
    }
}