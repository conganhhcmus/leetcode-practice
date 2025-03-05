#if DEBUG
namespace Contests_433_Q2;
#endif

public class Solution
{
    public int MinMaxSums(int[] nums, int k)
    {
        int n = nums.Length;
        long ans = 0;
        var op = new Operation(n: n);
        Array.Sort(nums);

        long[,] prefixSum = new long[k, n];
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0)
                {
                    prefixSum[0, j] = 1;
                    continue;
                }
                prefixSum[i, j] = op.Add(prefixSum[i - 1, j], op.Ckn(i, j));
            }
        }

        for (int i = 0; i < n; i++)
        {
            long freq = op.Add(
                prefixSum[Math.Min(k - 1, n - i - 1), n - i - 1], // frequency of nums[i] if it is minimum
                prefixSum[Math.Min(k - 1, i), i]); // frequency of nums[i] if it is maximum

            ans = op.Add(ans, op.Multiply(nums[i], freq));
        }

        return (int)ans;
    }
}

public class Operation
{
    private readonly int MOD;
    private long[] fact;
    private long[] invFact;

    public Operation(int mod = 1_000_000_007, int n = 100_000) // default value for modulo
    {
        MOD = mod;
        BuildFact(n);
    }

    private void BuildFact(int n)
    {
        fact = new long[n + 1];
        invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = Multiply(fact[i - 1], i);
        }
        invFact[0] = 1;
        invFact[n] = FastPower(fact[n], MOD - 2);
        for (int i = n - 1; i >= 1; i--)
        {
            invFact[i] = Multiply(invFact[i + 1], i + 1);
        }
    }

    public long Add(long a, long b) => (a + b) % MOD;
    public long Subtract(long a, long b) => Add(a, -b);
    public long Multiply(long a, long b) => ((a % MOD) * (b % MOD)) % MOD;
    public long Divide(long a, long b) => Multiply(a, ModularInverse(b));
    public long ModularInverse(long a) => FastPower(a, MOD - 2); // if MOD is prime
    public long FastPower(long a, long b)
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

    public long Ckn(long k, long n)
    {
        if (k > n || k < 0) return 0;

        // C k n = n! / (k! * (n-k)!)

        long ans = Multiply(fact[n], invFact[k]); // ans = n! / k!

        return Multiply(ans, invFact[n - k]); // ans = ans / (n-k)!
    }
}