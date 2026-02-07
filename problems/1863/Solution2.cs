public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int ans = 0;
        Recursion(nums, 0, 0, ref ans);
        return ans;
    }

    void Recursion(int[] nums, int pos, int xor, ref int ans)
    {
        int n = nums.Length;
        if (pos >= n)
        {
            ans += xor;
            return;
        }
        Recursion(nums, pos + 1, xor ^ nums[pos], ref ans);
        Recursion(nums, pos + 1, xor, ref ans);
    }
}