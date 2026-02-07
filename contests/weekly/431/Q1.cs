public class Solution
{
    long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    long LCM(long a, long b)
    {
        return (a * b) / GCD(a, b);
    }
    public int MaxLength(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            long prod = nums[i];
            long gcd = nums[i];
            long lcm = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                prod *= nums[j];
                gcd = GCD(gcd, nums[j]);
                lcm = LCM(lcm, nums[j]);
                if (prod == (gcd * lcm))
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }

        return ans;
    }
}