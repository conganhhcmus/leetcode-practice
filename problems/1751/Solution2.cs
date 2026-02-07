public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);
        int n = events.Length;
        int[,] dp = new int[n + 1, k + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int low = i + 1, high = n - 1, next = n;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (events[mid][0] > events[i][1])
                {
                    next = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            for (int j = 1; j <= k; j++)
            {
                dp[i, j] = Math.Max(dp[i + 1, j], dp[next, j - 1] + events[i][2]);
            }
        }
        return dp[0, k];
    }
}