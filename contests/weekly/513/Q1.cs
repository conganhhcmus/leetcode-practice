public class Solution
{
    public long MaxPairStrength(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                long gcd = Gcd(nums[i], nums[j]);
                long val = 1L * nums[i] * nums[j] / (gcd * gcd);
                if (ans < val) ans = val;
            }
        }
        return ans;

        long Gcd(long a, long b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}
