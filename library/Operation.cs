namespace Library;

public class Operation
{
    private int MOD;

    public Operation()
    {
        MOD = 1000000007; // default value for modulo
    }

    public Operation(int mod)
    {
        MOD = mod;
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
}