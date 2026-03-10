public class Solution
{
    int mod = (int)1e9 + 7;
    long[] fact;
    long[] invFact;

    long Pow(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }

    void Init(int n)
    {
        fact = new long[n + 1];
        invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i % mod;
        }
        invFact[n] = Pow(fact[n], mod - 2);
        for (int i = n; i > 0; i--)
        {
            invFact[i - 1] = invFact[i] * i % mod;
        }
    }

    long Ckn(int n, int k)
    {
        if (k < 0 || k > n) return 0;
        long num = fact[n];
        long den = invFact[k] * invFact[n - k] % mod;
        return num * den % mod;
    }

    // split n identical items into k blocks, each block size 1..limit
    long SplitWays(int n, int k, int limit)
    {
        long total = 0;
        int flag = 1;
        int remaining = n;
        for (int j = 0; j <= k && k <= remaining; j++)
        {
            long term = Ckn(k, j) * Ckn(remaining - 1, k - 1) % mod;
            total = (total + flag * term) % mod;
            if (total < 0) total += mod;
            flag = -flag;
            remaining -= limit;
        }

        return total;
    }

    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        Init(zero + one);
        int start = (Math.Min(zero, one) + limit - 1) / limit;
        long prev = 0;
        long curr = SplitWays(one, start, limit);
        long next = SplitWays(one, start + 1, limit);
        long ans = 0;

        for (int k = start; k <= zero; k++)
        {
            long choices = (prev + 2 * curr + next) % mod;
            choices = choices * SplitWays(zero, k, limit) % mod;
            ans = (ans + choices) % mod;
            prev = curr;
            curr = next;
            next = SplitWays(one, k + 2, limit);
        }
        return (int)ans;
    }
}