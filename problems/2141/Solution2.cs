#if DEBUG
namespace Problems_2141_2;
#endif

public class Solution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        Array.Sort(batteries);
        long extra = 0;
        int m = batteries.Length;
        for (int i = 0; i < m - n; i++)
        {
            extra += batteries[i];
        }

        int[] live = new int[n];
        Array.Copy(batteries, m - n, live, 0, n);

        for (int i = 0; i < n - 1; i++)
        {
            if (extra < (long)(i + 1) * (live[i + 1] - live[i]))
            {
                return live[i] + extra / (long)(i + 1);
            }
            extra -= (long)(i + 1) * (live[i + 1] - live[i]);
        }
        return live[n - 1] + extra / n;
    }
}