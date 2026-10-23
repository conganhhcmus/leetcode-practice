public class Solution
{
    public int SortPermutation(int[] nums)
    {
        int k = int.MaxValue; // full 1
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i) k &= nums[i];
        }
        return k == int.MaxValue ? 0 : k;
    }
}