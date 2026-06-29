public class Solution
{
    public IList<IList<int>> FilterOccupiedIntervals(int[][] occupiedIntervals, int freeStart, int freeEnd)
    {
        IList<IList<int>> ans = [];
        Array.Sort(occupiedIntervals, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        List<int[]> merged = [];
        int st = occupiedIntervals[0][0], ed = occupiedIntervals[0][1];
        for (int i = 1; i < occupiedIntervals.Length; i++)
        {
            if (occupiedIntervals[i][0] <= ed + 1)
            {
                ed = Math.Max(ed, occupiedIntervals[i][1]);
            }
            else
            {
                merged.Add([st, ed]);
                st = occupiedIntervals[i][0];
                ed = occupiedIntervals[i][1];
            }
        }
        merged.Add([st, ed]);
        foreach (int[] e in merged)
        {
            if (e[0] >= freeStart && e[1] <= freeEnd) continue;
            if (e[1] < freeStart || e[0] > freeEnd) ans.Add(e);
            else
            {
                if (e[0] < freeStart)
                {
                    ans.Add([e[0], freeStart - 1]);
                }
                if (e[1] > freeEnd)
                {
                    ans.Add([freeEnd + 1, e[1]]);
                }
            }
        }
        return ans;
    }
}
