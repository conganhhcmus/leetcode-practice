public class Solution
{
    public int[] SumAndMultiply(string s, int[][] queries)
    {
        int MOD = 1_000_000_007;
        int n = s.Length, m = queries.Length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            pref[i + 1] = pref[i] + (s[i] - '0');
        }
        long[] prefX = new long[n + 1];
        long[] prefB = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefX[i + 1] = prefX[i];
            prefB[i + 1] = prefB[i];
            if (s[i] == '0') continue;
            prefX[i + 1] = (prefX[i] * 10 + (s[i] - '0')) % MOD;
            prefB[i + 1] = prefB[i] + 1;
        }

        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            long sum = (pref[r + 1] - pref[l]) % MOD;
            long diff = prefB[r + 1] - prefB[l];
            long x = (prefX[r + 1] - prefX[l] * Pow(10, diff)) % MOD;
            if (sum < 0) sum += MOD;
            if (x < 0) x += MOD;
            long val = x * sum % MOD;
            ans[i] = (int)val;
        }
        return ans;

        long Pow(long a, long b)
        {
            long r = 1L;
            while (b > 0)
            {
                if ((b & 1) != 0) r = r * a % MOD;
                a = a * a % MOD;
                b >>= 1;
            }
            return r;
        }
    }
}
