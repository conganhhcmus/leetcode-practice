public class Solution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int[] bits = new int[32];
        for (int i = n - 1; i >= 0; i--)
        {
            int val = nums[i];
            for (int j = 0; j < 32; j++)
            {
                if ((val & (1 << j)) != 0) bits[j] = i;
            }
            int max = i;
            for (int j = 0; j < 32; j++)
            {
                if (bits[j] > max) max = bits[j];
            }
            ans[i] = max - i + 1;
        }
        return ans;
    }
}