public class Solution
{
    int mod = (int)1e9 + 7;

    long Power(long a, long b)
    {
        long ans = 1L;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = (ans * a) % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }

    long Inv(int a) => Power(a, mod - 2);

    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int B = (int)Math.Sqrt(n) + 1;

        // diff[k][rem][pos]
        long[][][] diff = new long[B + 1][][];
        long[] mul = new long[n + 1];
        Array.Fill(mul, 1L);
        for (int k = 1; k <= B; k++)
        {
            diff[k] = new long[k][];

            for (int r = 0; r < k; r++)
            {
                int size = (n - r + k - 1) / k + 2;

                diff[k][r] = new long[size];
                Array.Fill(diff[k][r], 1L);
            }
        }

        foreach (int[] q in queries)
        {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k > B)
            {
                for (int i = l; i <= r; i += k)
                {
                    mul[i] = mul[i] * v % mod;
                }
            }
            else
            {
                int rem = l % k;
                int st = (l - rem) / k;
                int ed = (r - rem) / k;
                diff[k][rem][st] = diff[k][rem][st] * v % mod;
                diff[k][rem][ed + 1] = diff[k][rem][ed + 1] * Inv(v) % mod;
            }
        }

        for (int k = 1; k <= B; k++)
        {
            for (int r = 0; r < k; r++)
            {
                long cur = 1;
                int idx = r;
                int pos = 0;
                while (idx < n)
                {
                    cur = cur * diff[k][r][pos] % mod;
                    mul[idx] = mul[idx] * cur % mod;

                    idx += k;
                    pos++;
                }
            }
        }

        int xor = 0;
        for (int i = 0; i < n; i++)
        {
            xor ^= (int)(nums[i] * mul[i] % mod);
        }
        return xor;
    }
}