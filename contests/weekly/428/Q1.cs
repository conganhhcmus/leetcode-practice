#if DEBUG
namespace Contests_428_Q1;
#endif

public class Solution
{
    public int ButtonWithLongestTime(int[][] events)
    {
        int ans = int.MaxValue;
        int max = 0;
        for (int i = 0; i < events.Length; i++)
        {
            if (i == 0)
            {
                if (max < events[i][1])
                {
                    ans = events[i][0];
                    max = events[i][1];
                }
            }
            else
            {
                if (max < events[i][1] - events[i - 1][1])
                {
                    ans = events[i][0];
                    max = events[i][1] - events[i - 1][1];
                }
                else if (max == events[i][1] - events[i - 1][1])
                {
                    ans = Math.Min(ans, events[i][0]);
                    max = events[i][1] - events[i - 1][1];
                }
            }
        }

        return ans;
    }
}