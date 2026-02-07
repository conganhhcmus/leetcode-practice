public class Solution
{
    public int SingleNumber(int[] nums)
    {
        // Time complexity: O(32*n)
        // Space complexity: O(1)
        int n = nums.Length;
        int ans = 0, k = 3;
        for (int bit = 0; bit < 32; bit++)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count += (nums[i] >> bit) & 1;
            }
            if (count % k == 1) ans |= 1 << bit;
        }

        return ans;
    }
}