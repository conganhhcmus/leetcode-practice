public class Solution
{
    int mod = (int)1e9 + 7;
    public int CountArrays(int[] digitSum)
    {
        // arr[i - 1] .. 5000
        // sum of digit arr[i] = digitSum
        // 4999 = 31
        List<int>[] map = new List<int>[32];
        for (int i = 0; i < 32; i++)
        {
            map[i] = [];
        }
        for (int i = 0; i <= 5000; i++)
        {
            int sum = 0;
            int t = i;
            while (t > 0)
            {
                sum += t % 10;
                t /= 10;
            }
            map[sum].Add(i);
        }
        int n = digitSum.Length;
        for (int i = 0; i < n; i++)
        {
            if (digitSum[i] > 31) return 0;
        }

        long[][] dp = new long[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new long[5001];
        }
        Array.Fill(dp[0], 1);
        for (int i = 1; i <= n; i++)
        {
            List<int> list = map[digitSum[i - 1]];
            foreach (int j in list)
            {
                dp[i][j] = (dp[i][j] + dp[i - 1][j]) % mod;
            }
            for (int j = 1; j <= 5000; j++)
            {
                dp[i][j] = (dp[i][j] + dp[i][j - 1]) % mod;
            }
        }

        return (int)dp[n][5000];
    }
}