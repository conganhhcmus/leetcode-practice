public class Solution
{
    public int MinimumSwaps(int[] nums)
    {
        int zeros = 0;
        int n = nums.Length;
        foreach (int num in nums)
        {
            if (num == 0) zeros++;
        }
        int ans = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (zeros == 0) break;
            if (nums[i] != 0) ans++;
            zeros--;
        }
        return ans;
    }
}
