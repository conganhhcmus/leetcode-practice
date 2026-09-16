public class Solution
{
    public int NumberOfSets(int n, int k)
    {
        int mod = (int)1e9 + 7;
        // we need k segments so need to choose 2*k points
        // the segment can share points so we have max k - 1 share point
        // we must choose 2*k points from n + k - 1 points
        // ans = C(n + k - 1, 2*k)

        int m = 2 * k;
        long num = 1, den = 1;
        for (int i = 1; i <= m; i++)
        {
            num = num * (n + k - i) % mod;
            den = den * i % mod;
        }
        long invDen = QuickPow(den, mod - 2);

        return (int)(num * invDen % mod);

        long QuickPow(long a, long e)
        {
            long ans = 1;
            while (e > 0)
            {
                if ((e & 1) != 0) ans = ans * a % mod;
                a = a * a % mod;
                e >>= 1;
            }
            return ans;
        }
    }
}