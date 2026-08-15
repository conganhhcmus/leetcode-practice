public class Solution
{
    public int LongestSubsequence(int[] nums)
    {
        int n = nums.Length;
        int xor = 0;
        bool have = false;
        for (int i = 0; i < n; i++)
        {
            xor ^= nums[i];
            if (nums[i] > 0) have = true;
        }
        if (xor != 0) return n;
        if (have) return n - 1;
        return 0;
    }
}
