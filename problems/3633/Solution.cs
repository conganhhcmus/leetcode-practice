public class Solution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int ans = int.MaxValue;
        int n = landDuration.Length;
        int m = waterDuration.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int st1 = landStartTime[i];
                int ed1 = st1 + landDuration[i];
                int st2 = waterStartTime[j];
                int ed2 = st2 + waterDuration[j];

                int val = Math.Max(Math.Min(st1, st2) + landDuration[i] + waterDuration[j], Math.Max(ed1, ed2));

                ans = Math.Min(ans, val);
            }
        }
        return ans;
    }
}
