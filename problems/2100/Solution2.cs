#if DEBUG
namespace Problems_2100_2;
#endif

public class Solution
{
    public IList<int> GoodDaysToRobBank(int[] security, int time)
    {
        int n = security.Length;
        int[] dpNI = new int[n];
        int[] dpND = new int[n];
        for (int i = 1; i < n; i++)
        {
            if (security[i - 1] >= security[i])
            {
                dpNI[i] = dpNI[i - 1] + 1;
            }
            else
            {
                dpNI[i] = 0;
            }
        }
        for (int i = n - 2; i >= 0; i--)
        {
            if (security[i] <= security[i + 1])
            {
                dpND[i] = dpND[i + 1] + 1;
            }
            else
            {
                dpND[i] = 0;
            }
        }

        IList<int> ret = [];
        for (int i = 0; i < n; i++)
        {
            if (dpND[i] >= time && dpNI[i] >= time) ret.Add(i);
        }
        return ret;
    }
}