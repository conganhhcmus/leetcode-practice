public class Solution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int minFinishWater = FindMinFinishTime(waterStartTime, waterDuration, 0);
        int minFinishLand = FindMinFinishTime(landStartTime, landDuration, 0);

        int min12 = FindMinFinishTime(landStartTime, landDuration, minFinishWater);
        int min21 = FindMinFinishTime(waterStartTime, waterDuration, minFinishLand);

        return Math.Min(min12, min21);
    }

    int FindMinFinishTime(int[] start, int[] duration, int prev)
    {
        int ans = int.MaxValue;
        int n = start.Length;
        for (int i = 0; i < n; i++)
        {
            ans = Math.Min(ans, Math.Max(prev, start[i]) + duration[i]);
        }
        return ans;
    }
}
