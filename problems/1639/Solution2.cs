#if DEBUG
namespace Problems_1639_2;
#endif

public class Solution
{
    const int MOD = 1_000_000_007;
    long Add(long a, long b) => (a + b) % MOD;
    long Subtract(long a, long b) => Add(a, -b);
    long Multiply(long a, long b) => ((a % MOD) * (b % MOD)) % MOD;
    long Divide(long a, long b) => Multiply(a, ModularInverse(b));
    long ModularInverse(long a) => Power(a, MOD - 2); // if MOD is prime
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
    public int NumWays(string[] words, string target)
    {
        int n = words[0].Length, m = target.Length;
        int[,] map = new int[n, 26];
        for (int i = 0; i < n; i++)
        {
            foreach (var word in words)
            {
                map[i, word[i] - 'a']++;
            }
        }
        var dp = new long[m + 1];
        dp[0] = 1;
        for (int idxWord = 0; idxWord < n; idxWord++)
        {
            for (int idxTarget = m; idxTarget > 0; idxTarget--)
            {
                dp[idxTarget] = Add(dp[idxTarget], Multiply(map[idxWord, target[idxTarget - 1] - 'a'], dp[idxTarget - 1]));
            }
        }

        return (int)dp[m];
    }
}