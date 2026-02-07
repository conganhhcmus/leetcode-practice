public class Solution
{
    const int MOD = 1_000_000_007;
    long Add(long a, long b) => (a + b) % MOD;
    long Subtract(long a, long b) => Add(a, -b);
    long Multiply(long a, long b) => ((a % MOD) * (b % MOD)) % MOD;
    long Divide(long a, long b) => Multiply(a, ModularInverse(b));
    long ModularInverse(long a) => Power(a, MOD - 2);
    long Power(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = Multiply(ans, a);
            }
            a = Multiply(a, a);
            b >>= 1;
        }
        return ans;
    }
    public int CountGoodArrays(int n, int m, int k)
    {
        // We have (n-1) pairs, so we need to choose k positions from these (n-1) pairs. This gives us C(k, n-1) possible ways.
        // For the k chosen pairs (arr[i] == arr[i-1]), we have m possible values.
        // For the remaining (n-1-k) indices, we have (m-1) choices for their values, resulting in (m-1)^(n-1-k) possible ways.
        // Therefore, the answer is m * (m-1)^(n-1-k) * C(k, n-1).

        return (int)Multiply(Multiply(m, Power(m - 1, n - 1 - k)), Ckn(k, n - 1));
    }

    private long Ckn(long k, long n)
    {
        if (k == 0 || n <= 1) return 1;
        if (k == 1) return Math.Max(n, 1);

        // C k n = n! / k! * (n-k)! = n*(n-1)*..*(n-k+1) / k!

        long kFact = 1, multiCons = 1;
        for (long i = 1; i <= k; i++) kFact = Multiply(kFact, i);
        for (long i = n; i >= n - k + 1; i--) multiCons = Multiply(multiCons, i);

        return Divide(multiCons, kFact);
    }
}