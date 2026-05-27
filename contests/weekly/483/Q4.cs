public class Solution
{
    public long MinMergeCost(int[][] lists)
    {
        int n = lists.Length;
        int fullMask = 1 << n;
        int[] len = new int[fullMask];
        int[] med = new int[fullMask];
        for (int m = 1; m < fullMask; m++)
        {
            List<int> arr = [];
            for (int i = 0; i < n; i++)
            {
                if ((m & (1 << i)) != 0)
                {
                    arr.AddRange(lists[i]);
                }
            }
            arr.Sort();
            // len, avg
            len[m] = arr.Count;
            med[m] = arr[(arr.Count - 1) / 2];
        }

        long INF = 1L << 60;
        long[] dp = new long[fullMask];
        Array.Fill(dp, INF);
        for (int i = 0; i < n; i++)
        {
            dp[1 << i] = 0;
        }
        for (int mask = 0; mask < fullMask; mask++)
        {
            for (int sub = (mask - 1) & mask; sub > 0; sub = (sub - 1) & mask)
            {
                int rem = sub ^ mask;
                dp[mask] = Math.Min(dp[mask], dp[sub] + dp[rem] + (len[sub] + len[rem] + Math.Abs(med[sub] - med[rem])));
            }
        }

        return dp[fullMask - 1];
    }
}
