#if DEBUG
namespace Problems_134;
#endif

public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;
        long diff = 0;
        for (int i = 0; i < n; i++) diff += gas[i] - cost[i];

        if (diff < 0) return -1;
        diff = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            diff += gas[i] - cost[i];
            if (diff < 0)
            {
                ans = i + 1;
                diff = 0;
            }
        }

        return ans;
    }
}