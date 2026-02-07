public class Solution
{
    public int PossibleStringCount(string word, int k)
    {
        int mod = (int)1e9 + 7;
        int n = word.Length;
        if (n < k) return 0;
        if (n == k) return 1;
        List<int> freq = [];
        int prev = 0;
        for (int i = 0; i < n; i++)
        {
            if (word[i] != word[prev])
            {
                freq.Add(i - prev);
                prev = i;
            }
        }
        freq.Add(n - prev);

        long total = 1;
        foreach (int val in freq)
        {
            total = total * val % mod;
        }

        if (freq.Count >= k) return (int)total;
        int need = k - freq.Count;
        long[] dp = new long[need];
        dp[0] = 1;
        for (int i = 0; i < freq.Count; i++)
        {
            int max = Math.Min(freq[i], need) - 1;
            long[] pre = new long[need + 1];
            for (int j = 1; j <= need; j++)
            {
                pre[j] = (pre[j - 1] + dp[j - 1]) % mod;
            }

            for (int j = 0; j < need; j++)
            {
                dp[j] = (pre[j + 1] - pre[Math.Max(0, j - max)] + mod) % mod;
            }
        }

        long invalid = 0;
        for (int i = 0; i < need; i++)
        {
            invalid = (invalid + dp[i]) % mod;
        }

        return (int)((total - invalid + mod) % mod);
    }
}