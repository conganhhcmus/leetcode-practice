public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        HashSet<int> del = [];
        for (int i = 0; i < n; i++)
        {
            int a = intervals[i][0], b = intervals[i][1];
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                int c = intervals[j][0], d = intervals[j][1];
                if (a >= c && d >= b)
                {
                    del.Add(i);
                    break;
                }
            }
        }
        return n - del.Count;
    }
}
