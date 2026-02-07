public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        int maxIJ = 0, maxI = 0;
        for (int k = 0; k < n; k++)
        {
            ans = Math.Max(ans, 1L * maxIJ * nums[k]);
            maxIJ = Math.Max(maxIJ, maxI - nums[k]);
            maxI = Math.Max(maxI, nums[k]);
        }
        return ans;
    }
}