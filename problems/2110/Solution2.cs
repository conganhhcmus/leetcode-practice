#if DEBUG
namespace Problems_2110_2;
#endif

public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        int n = prices.Length;
        long ret = n;
        long count = 0;
        for (int i = 1; i < n; i++)
        {
            if (prices[i - 1] - prices[i] == 1)
            {
                count++;
            }
            else
            {
                count = 0;
            }
            ret += count;
        }

        return ret;
    }
}