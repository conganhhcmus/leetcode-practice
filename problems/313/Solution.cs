#if DEBUG
namespace Problems_313;
#endif

class Solution
{
    public int NthSuperUglyNumber(int n, int[] primes)
    {
        int[] dp = new int[n];
        int k = primes.Length;
        int[] idx = new int[k];
        long[] next = new long[k];
        dp[0] = 1;
        for (var i = 0; i < k; i++) next[i] = primes[i];
        for (var i = 1; i < n; i++)
        {
            var min = next[0];
            for (var j = 1; j < k; j++)
            {
                if (next[j] < min) min = next[j];
            }

            dp[i] = (int)min;
            for (var j = 0; j < k; j++)
            {
                if (next[j] == min)
                {
                    idx[j]++;
                    next[j] = 1L * primes[j] * dp[idx[j]];
                }
            }
        }
        return dp[n - 1];
    }
}