#if DEBUG
namespace Problems_1014;
#endif

public class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        int n = values.Length, preMax = values[0];
        int ans = int.MinValue;
        for (int i = 1; i < n; i++)
        {
            ans = Math.Max(ans, preMax + values[i] - i);
            if (preMax < values[i] + i) preMax = values[i] + i;
        }
        return ans;
    }
}