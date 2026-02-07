public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans |= nums[i];
        }
        return ans << (n - 1);
    }
}