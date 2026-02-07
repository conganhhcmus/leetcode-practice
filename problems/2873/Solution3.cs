public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        int maxI = 0, maxIJ = 0;

        for (int k = 0; k < n; k++)
        {
            ans = Math.Max(ans, 1L * nums[k] * maxIJ);
            maxIJ = Math.Max(maxIJ, maxI - nums[k]);
            maxI = Math.Max(maxI, nums[k]);
        }
        return ans;
    }
}