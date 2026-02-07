public class Solution
{
    int Compare(List<int> a, List<int> b)
    {
        int n1 = a.Count, n2 = b.Count;
        for (int i = 0; i < Math.Min(n1, n2); i++)
        {
            if (a[i] != b[i]) return a[i] - b[i];
        }
        return n1 - n2;
    }
    public int[] MaximumWeight(IList<IList<int>> intervals)
    {
        int n = intervals.Count;
        int[][] intervalsNew = new int[n][];
        for (int i = 0; i < n; i++) intervalsNew[i] = [.. intervals[i], i];
        Array.Sort(intervalsNew, (a, b) =>
        {
            if (a[1] == b[1]) return a[0] - b[0];
            return a[1] - b[1];
        });
        int[] prev = new int[n];
        for (int i = 0; i < n; i++)
        {
            int left = 0, right = i - 1, need = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (intervalsNew[mid][1] < intervalsNew[i][0])
                {
                    need = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            prev[i] = need;
        }

        (long max, List<int> vals)[,] dp = new (long, List<int>)[5, n + 1];
        for (int i = 0; i <= n; i++) dp[0, i] = (0, []);

        for (int r = 1; r <= 4; r++)
        {
            for (int i = 1; i <= n; i++)
            {
                var (a, avals) = dp[r, i - 1];
                var (b, bvals) = (prev[i - 1] != -1) ? dp[r - 1, prev[i - 1] + 1] : (0, []);
                b += intervalsNew[i - 1][2];
                bvals = [.. bvals, intervalsNew[i - 1][3]];
                bvals.Sort();

                if (a > b)
                {
                    dp[r, i] = (a, avals);
                }
                else if (a < b)
                {
                    dp[r, i] = (b, bvals);
                }
                else
                {
                    dp[r, i] = (a, (Compare(avals, bvals) < 0) ? avals : bvals);
                }
            }
        }

        return [.. dp[4, n].vals];
    }
}