public class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            res[i] = res[i + n] = nums[i];
        }
        return res;
    }
}