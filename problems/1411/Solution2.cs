public class Solution
{
    int mod = (int)1e9 + 7;
    public int NumOfWays(int n)
    {
        // for 2 unique, there are 3 ways to have next one be 2 unique
        // for 2 unique, there are 2 ways to have next one be 3 unique
        // for 3 unique, there are 2 ways to have next one be 2 unique
        // for 3 unique, there are 2 ways to have next one be 3 unique
        long[] value = [6, 0, 6, 0];
        long[] matrix = [3, 2, 2, 2];

        n -= 1;
        while (n > 0)
        {
            if ((n & 1) != 0)
            {
                value = Multiple(matrix, value);
            }
            n >>= 1;
            matrix = Multiple(matrix, matrix);
        }
        long ans = 0;
        foreach (int v in value)
        {
            ans = (ans + v) % mod;
        }
        return (int)ans;
    }

    long[] Multiple(long[] a, long[] b)
    {
        long[] c = [0, 0, 0, 0];
        c[0] = (a[0] * b[0] + a[1] * b[2]) % mod;
        c[1] = (a[0] * b[1] + a[1] * b[3]) % mod;
        c[2] = (a[2] * b[0] + a[3] * b[2]) % mod;
        c[3] = (a[2] * b[1] + a[3] * b[3]) % mod;
        return c;
    }
}