public class Solution
{
    public int IdealArrays(int n, int maxValue)
    {
        int mod = (int)1e9 + 7;
        // dp[n][k] : how many distinct plans to place k same factors in n places (allowing multiple factors in the same place)
        // dp[i][j] = sum { dp[i-1][j-t] } where t = 0,1,2...j
        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new long[15]; // 2^14 > 1e4
        }
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i][0] = 1;
            for (int j = 1; j <= 14; j++)
            {
                // for (int t = 0; t <= j; t++)
                // {
                //     dp[i][j] = (dp[i][j] + dp[i - 1][j - t]) % mod;
                // }
                dp[i][j] = (dp[i][j - 1] + dp[i - 1][j]) % mod;
            }
        }

        int[] spf = BuildSpf(maxValue);
        long ret = 0;
        for (int i = 1; i <= maxValue; i++)
        {
            Dictionary<int, int> map = CountPrimeFactors(i, spf);
            long ans = 1;
            foreach (int count in map.Values)
            {
                ans = ans * dp[n][count] % mod;
            }
            ret = (ret + ans) % mod;
        }

        return (int)ret;
    }

    int[] BuildSpf(int maxValue)
    {
        int[] spf = new int[maxValue + 1];
        for (int i = 2; i <= maxValue; i++) spf[i] = i;
        for (int i = 2; i <= maxValue; i++)
        {
            if (spf[i] == i)
            {
                for (int j = 2 * i; j <= maxValue; j += i)
                {
                    if (spf[j] == j) spf[j] = i;
                }
            }
        }

        return spf;
    }

    Dictionary<int, int> CountPrimeFactors(int num, int[] spf)
    {
        Dictionary<int, int> map = [];
        while (num > 1)
        {
            int prime = spf[num];
            map[prime] = map.GetValueOrDefault(prime, 0) + 1;
            num /= prime;
        }

        return map;
    }
}