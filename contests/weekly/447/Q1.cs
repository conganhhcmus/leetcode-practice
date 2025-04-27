#if DEBUG
namespace Weekly_447_Q1;
#endif

public class Solution
{
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        List<int>[] cols = new List<int>[n + 1];
        List<int>[] rows = new List<int>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            cols[i] = [];
            rows[i] = [];
        }
        foreach (int[] building in buildings)
        {
            int x = building[0], y = building[1];
            cols[y].Add(x);
            rows[x].Add(y);
        }

        for (int i = 0; i <= n; i++)
        {
            cols[i].Sort();
            rows[i].Sort();
        }
        int ret = 0;
        foreach (int[] building in buildings)
        {
            int x = building[0], y = building[1];
            int xIdx = cols[y].BinarySearch(x);
            int yIdx = rows[x].BinarySearch(y);
            if (yIdx > 0 && yIdx < rows[x].Count - 1 && xIdx > 0 && xIdx < cols[y].Count - 1) ret++;
        }
        return ret;
    }
}
//©leetcode