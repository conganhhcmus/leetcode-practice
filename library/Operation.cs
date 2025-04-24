namespace Library;

public class Operation
{
    int mod = (int)1e9 + 7;

    private void BuildFact(int n)
    {
        long[] fact = new long[n + 1];
        long[] invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = Multiply(fact[i - 1], i);
        }
        invFact[0] = 1;
        invFact[n] = FastPower(fact[n], mod - 2);
        for (int i = n - 1; i >= 1; i--)
        {
            invFact[i] = Multiply(invFact[i + 1], i + 1);
        }
    }

    public long Add(long a, long b) => (a + b) % mod;
    public long Subtract(long a, long b) => Add(a, -b);
    public long Multiply(long a, long b) => ((a % mod) * (b % mod)) % mod;
    public long Divide(long a, long b) => Multiply(a, ModInverse(b));
    public long ModInverse(long a) => FastPower(a, mod - 2); // if mod is prime

    public long ModInverse(long a, int mod) // if mod is prime
    {
        long ret = 1;
        while (a > 1)
        {
            ret = ret * (mod - mod / a) % mod;
            a = mod % a;
        }
        return ret;
    }

    public int[] AllInv(int m) // if m is prime
    {
        int[] inv = new int[m];
        inv[1] = 1;
        for (int i = 2; i < m; i++)
        {
            inv[i] = (m - (m / i) * inv[m % i] % m) % m;
        }
        return inv;
    }

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

    public long Ckn(int k, int n, long[] fact, long[] invFact)
    {
        if (k > n || k < 0) return 0;
        k = Math.Min(k, n - k);
        // C k n = n! / (k! * (n-k)!)

        long ans = Multiply(fact[n], invFact[k]); // ans = n! / k!

        return Multiply(ans, invFact[n - k]); // ans = ans / (n-k)!
    }

    public long Ckn(int k, int n)
    {
        if (k > n || k < 0) return 0;
        k = Math.Min(k, n - k);
        long ret = 1;
        for (int i = 1; i <= k; i++)
        {
            ret *= n - i + 1;
            ret /= i;
        }
        return ret;
    }
}