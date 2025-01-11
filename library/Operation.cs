namespace Library;

public class Operation
{
    const int MOD = 1_000_000_007;
    long Add(long a, long b) => (a + b) % MOD;
    long Subtract(long a, long b) => Add(a, -b);
    long Multiply(long a, long b) => ((a % MOD) * (b % MOD)) % MOD;
    long Divide(long a, long b) => Multiply(a, ModularInverse(b));
    long ModularInverse(long a) => FastPower(a, MOD - 2); // if MOD is prime
    long FastPower(long a, long b)
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
}