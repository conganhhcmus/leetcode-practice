public class Solution
{
    public long MaxSubarrays(int n, int[][] conflictingPairs)
    {
        int m = conflictingPairs.Length;
        for (int i = 0; i < m; i++)
        {
            if (conflictingPairs[i][0] > conflictingPairs[i][1])
            {
                (conflictingPairs[i][1], conflictingPairs[i][0]) = (conflictingPairs[i][0], conflictingPairs[i][1]);
            }
        }

        Array.Sort(conflictingPairs, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });

        long[] diff = new long[n + 1];
        int j = m - 1;
        int min1 = n + 1;
        int min2 = n + 1;
        long total = 0L;
        for (int i = n; i > 0; i--)
        {
            while (j >= 0 && conflictingPairs[j][0] >= i)
            {
                int u = conflictingPairs[j][1];
                if (u < min1)
                {
                    min2 = min1;
                    min1 = u;
                }
                else if (u < min2)
                {
                    min2 = u;
                }
                j--;
            }

            total += Math.Min(n, min1 - 1) - i + 1;
            diff[min1 - 1] += Math.Min(n + 1, min2) - Math.Min(min1, n + 1);
        }
        long add = 0;
        for (int i = 0; i < n + 1; i++)
        {
            add = Math.Max(add, diff[i]);
        }
        return add + total;
    }
}