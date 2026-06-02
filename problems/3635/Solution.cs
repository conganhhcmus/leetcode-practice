public class Solution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int n = landStartTime.Length;
        int m = waterStartTime.Length;
        int MAX = 300_000;
        // ed1 and ed2
        int low = 0, high = MAX, ans = MAX;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;

        bool Ok(int k)
        {
            // check land -> water
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (k >= landStartTime[i] + landDuration[i])
                {
                    max = Math.Max(max, k - landDuration[i]);
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (max >= waterStartTime[i] + waterDuration[i]) return true;
            }
            // check water -> land
            max = 0;
            for (int i = 0; i < m; i++)
            {
                if (k >= waterStartTime[i] + waterDuration[i])
                {
                    max = Math.Max(max, k - waterDuration[i]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (max >= landStartTime[i] + landDuration[i]) return true;
            }
            return false;
        }
    }
}
