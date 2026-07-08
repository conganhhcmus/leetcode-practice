public class Solution
{
    public int MaxValidPairSum(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = -1;
        int[] suff = new int[n + 1];
        suff[n] = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            suff[i] = Math.Max(suff[i + 1], nums[i]);
        }
        for (int i = 0; i < n; i++)
        {
            int j = i + k;
            if (j >= n) continue;
            ans = Math.Max(ans, nums[i] + suff[j]);
        }
        return ans;
    }
}
