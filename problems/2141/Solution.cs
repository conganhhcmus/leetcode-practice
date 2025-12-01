#if DEBUG
namespace Problems_2141;
#endif

public class Solution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        long tot = 0;
        foreach (int power in batteries)
        {
            tot += power;
        }
        long low = 0, high = tot / n;
        long ans = 0;
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            long extra = 0;
            foreach (int power in batteries)
            {
                extra += Math.Min(power, mid);
            }
            if (extra / n >= mid)
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }
}