public class Solution
{
    public long ElevatorRequests(int n, int start, int[] requests)
    {
        List<int> arr = [];
        arr.Add(start);
        foreach (int req in requests)
        {
            if (req != start) arr.Add(req);
        }
        arr.Sort();
        int N = arr.Count;
        long[][][] dp = new long[N][][];
        long INF = 1L << 60;
        for (int i = 0; i < N; i++)
        {
            dp[i] = new long[N][];
            for (int j = 0; j < N; j++)
            {
                dp[i][j] = [INF, INF];
            }
        }

        int st = arr.BinarySearch(start);
        dp[st][st][0] = dp[st][st][1] = 0;
        for (int len = 1; len <= N; len++)
        {
            for (int l = 0; l + len - 1 < N; l++)
            {
                int r = l + len - 1;

                int remaining = N - len;

                long curLeft = dp[l][r][0];
                if (curLeft != INF)
                {
                    if (l > 0)
                    {
                        long dist = arr[l] - arr[l - 1];
                        dp[l - 1][r][0] = Math.Min(dp[l - 1][r][0], curLeft + dist * remaining);
                    }

                    if (r + 1 < N)
                    {
                        long dist = arr[r + 1] - arr[l];
                        dp[l][r + 1][1] = Math.Min(dp[l][r + 1][1], curLeft + dist * remaining);
                    }
                }

                long curRight = dp[l][r][1];
                if (curRight != INF)
                {
                    if (l > 0)
                    {
                        long dist = arr[r] - arr[l - 1];
                        dp[l - 1][r][0] = Math.Min(dp[l - 1][r][0], curRight + dist * remaining);
                    }

                    if (r + 1 < N)
                    {
                        long dist = arr[r + 1] - arr[r];
                        dp[l][r + 1][1] = Math.Min(dp[l][r + 1][1], curRight + dist * remaining);
                    }
                }
            }
        }


        return Math.Min(dp[0][N - 1][0], dp[0][N - 1][1]);
    }
}
