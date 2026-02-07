#if DEBUG
using Microsoft.VisualBasic;

#endif

public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);
        return DP(events, k, 0);
    }

    readonly Dictionary<(int, int), int> memo = [];

    int DP(int[][] events, int remain, int pos)
    {
        if (remain == 0 || pos >= events.Length) return 0;

        var key = (remain, pos);
        if (memo.TryGetValue(key, out int cached)) return cached;
        // choose it
        // 1. pick it
        // 2. find next pos is valid
        // 3. plus DP
        int low = pos + 1, high = events.Length - 1, next = events.Length;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (events[mid][0] > events[pos][1])
            {
                next = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        int pick = events[pos][2] + DP(events, remain - 1, next);

        // skip it
        int skip = DP(events, remain, pos + 1);

        return memo[key] = Math.Max(pick, skip);
    }
}