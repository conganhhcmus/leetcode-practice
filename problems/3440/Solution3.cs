public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;

        int ans = 0;
        int t1 = 0, t2 = 0;
        for (int i = 0; i < n; i++)
        {
            int left1 = i == 0 ? 0 : endTime[i - 1];
            int right1 = i == n - 1 ? eventTime : startTime[i + 1];

            // move earlier
            if (endTime[i] - startTime[i] <= t1)
            {
                ans = Math.Max(ans, right1 - left1);
            }
            t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            int left2 = i == n - 1 ? 0 : endTime[n - i - 2];
            int right2 = i == 0 ? eventTime : startTime[n - i];
            // move later
            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2)
            {
                ans = Math.Max(ans, right2 - left2);
            }
            t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);

            // cannot move
            ans = Math.Max(ans, right1 - left1 - (endTime[i] - startTime[i]));
        }

        return ans;
    }
}