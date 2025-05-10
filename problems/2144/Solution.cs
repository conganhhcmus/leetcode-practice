#if DEBUG
namespace Problems_2144;
#endif

public class Solution
{
    public int MinimumCost(int[] cost)
    {
        int n = cost.Length;
        Array.Sort(cost, (a, b) => b - a);
        int ret = 0;
        for (int i = 0; i < n; i += 3)
        {
            if (i < n) ret += cost[i];
            if (i + 1 < n) ret += cost[i + 1];
        }

        return ret;
    }
}