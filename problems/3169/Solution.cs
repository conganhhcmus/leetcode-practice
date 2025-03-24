#if DEBUG
namespace Problems_3169;
#endif

public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        int lastMeetingDay = 0;
        int ans = 0;
        foreach (int[] meeting in meetings)
        {
            int start = meeting[0], end = meeting[1];
            if (start > lastMeetingDay)
            {
                ans += start - lastMeetingDay - 1; // exclude [a, b] as (a, b) ~ b - a - 1
            }
            lastMeetingDay = Math.Max(lastMeetingDay, end);
        }
        if (days > lastMeetingDay)
        {
            ans += days - lastMeetingDay;
        }

        return ans;
    }
}