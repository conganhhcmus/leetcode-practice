#if DEBUG
namespace Contests_438_Q3;
#endif

public class Solution
{
    public bool HasSameDigits(string s)
    {
        int n = s.Length;
        int[] param = BuildParam(n - 2);
        // Console.WriteLine(string.Join(",", param));
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            sum1 = (sum1 + param[i] * (s[i] - '0')) % 10;
            sum2 = (sum2 + param[i] * (s[i + 1] - '0')) % 10;
        }

        return sum1 == sum2;
    }

    int[] BuildParam(int m)
    {
        int[] coeff = new int[m + 1]; // Binomial Coefficient
        var (fact2, invFact2) = BuildFactAndInvFact(m, 2);
        var (fact5, invFact5) = BuildFactAndInvFact(m, 5);

        for (int i = 0; i <= m; i++)
        {
            // kCn = n! / (k! * (n-k)!)
            int kCnMod2 = fact2[m] * invFact2[i] * invFact2[m - i] % 2;
            int kCnMod5 = fact5[m] * invFact5[i] * invFact5[m - i] % 5;
            coeff[i] = ComputeMod10(kCnMod2, kCnMod5);
        }
        return coeff;
    }

    private int ComputeMod10(int a, int b)
    {
        // x ≡ a (mod 2)
        // x ≡ b (mod 5)
        // Find x mod 10 using the Chinese Remainder Theorem
        for (int x = 0; x < 10; x++)
        {
            if (x % 2 == a && x % 5 == b) return x;
        }

        return -1;
    }

    private (int[] fact, int[] invFact) BuildFactAndInvFact(int n, int mod)
    {
        int[] fact = new int[n + 1];
        int[] invFact = new int[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i % mod;
        }
        invFact[0] = 1;
        invFact[n] = FastPower(fact[n], mod - 2, mod); // where mod is prime
        for (int i = n - 1; i >= 1; i--)
        {
            invFact[i] = invFact[i + 1] * (i + 1) % mod;
        }

        return (fact, invFact);
    }

    private int FastPower(int a, int b, int mod)
    {
        int ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }

        return ans;
    }
}