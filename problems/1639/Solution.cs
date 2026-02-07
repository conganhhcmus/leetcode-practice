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
        int[,] memo = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                memo[i, j] = -1;

        long DP(int idx, int pos)
        {
            if (pos == m) return 1;
            if (idx == n || n - idx < m - pos) return 0;
            if (memo[idx, pos] != -1) return memo[idx, pos];

            int ways = map[idx, target[pos] - 'a'];
            long ans = DP(idx + 1, pos);
            if (ways > 0) ans = Add(ans, Multiply(DP(idx + 1, pos + 1), ways));
            memo[idx, pos] = (int)ans;
            return ans;
        }

        return (int)DP(0, 0);
    }
}