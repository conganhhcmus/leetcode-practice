#if DEBUG
namespace Problems_3439;
#endif

public class Solution
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int[] sp = new int[n + 1];
        sp[0] = startTime[0];
        sp[n] = eventTime - endTime[^1];
        for (int i = 1; i < n; i++)
        {
            sp[i] = startTime[i] - endTime[i - 1];
        }

        int ans = 0;
        int sum = 0;
        k = Math.Min(k + 1, n + 1);
        for (int i = 0; i < k; i++)
        {
            sum += sp[i];
        }
        ans = Math.Max(ans, sum);
        for (int i = k; i < n + 1; i++)
        {
            sum += sp[i] - sp[i - k];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}