#if DEBUG
namespace Problems_3440_2;
#endif

public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        bool[] can = new bool[n];
        int t = 0;
        // can move earlier
        for (int i = 0; i < n; i++)
        {
            if (endTime[i] - startTime[i] <= t)
            {
                can[i] = true;
            }
            t = Math.Max(t, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));
        }
        // can move later
        t = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (endTime[i] - startTime[i] <= t)
            {
                can[i] = true;
            }
            t = Math.Max(t, (i == n - 1 ? eventTime : startTime[i + 1]) - endTime[i]);
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (can[i])
            {
                ans = Math.Max(ans, right - left);
            }
            else
            {
                ans = Math.Max(ans, right - left - (endTime[i] - startTime[i]));
            }
        }

        return ans;
    }
}