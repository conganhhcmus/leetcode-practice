#if DEBUG
namespace Problems_3343_2;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int CountBalancedPermutations(string num)
    {
        int n = num.Length;
        int[] count = new int[10];
        int sum = 0;
        foreach (char d in num)
        {
            count[d - '0']++;
            sum += d - '0';
        }

        if (sum % 2 != 0) return 0;
        int target = sum / 2;
        int maxOdd = (num.Length + 1) / 2;
        long[] fact = new long[n + 1];
        long[] invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = (fact[i - 1] * i) % mod;
        }
        invFact[0] = 1;
        invFact[n] = FastPower(fact[n], mod - 2);
        for (int i = n - 1; i >= 1; i--)
        {
            invFact[i] = (invFact[i + 1] * (i + 1)) % mod;
        }

        long[,] dp = new long[target + 1, maxOdd + 1];
        dp[0, 0] = 1;
        foreach (char c in num)
        {
            int d = c - '0';
            for (int i = target; i >= d; i--)
            {
                for (int j = maxOdd; j > 0; j--)
                {
                    dp[i, j] = (dp[i, j] + dp[i - d, j - 1]) % mod;
                }
            }
        }

        long ret = dp[target, maxOdd];
        ret = ((ret * fact[maxOdd] % mod) * fact[n - maxOdd]) % mod;
        foreach (int i in count)
        {
            ret = ret * invFact[i] % mod;
        }
        return (int)ret;
    }

    public long FastPower(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = (ans * a) % mod;
            }
            a = (a * a) % mod;
            b >>= 1;
        }
        return ans;
    }

}