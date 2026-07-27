public class Solution
{
    public IList<IList<int>> AggregateTimeSeries(int[][] series1, int[][] series2)
    {
        IList<IList<int>> ans = [];
        int i = 0, j = 0;
        while (i < series1.Length && j < series2.Length)
        {
            int t1 = series1[i][0], v1 = series1[i][1];
            int t2 = series2[j][0], v2 = series2[j][1];
            if (t1 == t2)
            {
                ans.Add([t1, v1 + v2]);
                i++;
                j++;
            }
            else if (t1 < t2)
            {
                ans.Add([t1, v1 + v2]);
                i++;
            }
            else if (t1 > t2)
            {
                ans.Add([t2, v1 + v2]);
                j++;
            }
        }
        while (i < series1.Length)
        {
            ans.Add([series1[i][0], series1[i][1]]);
            i++;
        }
        while (j < series2.Length)
        {
            ans.Add([series2[j][0], series2[j][1]]);
            j++;
        }
        return ans;
    }
}
