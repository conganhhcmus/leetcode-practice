#if DEBUG
namespace Problems_2054;
#endif

public class Solution
{
    public int MaxTwoEvents(int[][] events)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);
        PriorityQueue<(int end, int val), int> pq = new();
        int maxVal = 0, ans = 0;
        for (int i = 0; i < events.Length; i++)
        {
            while (pq.Count > 0 && pq.Peek().end < events[i][0])
            {
                maxVal = Math.Max(maxVal, pq.Dequeue().val);
            }
            pq.Enqueue((events[i][1], events[i][2]), events[i][1]);
            ans = Math.Max(ans, maxVal + events[i][2]);
        }

        return ans;
    }
    // public int MaxTwoEvents(int[][] events)
    // {
    //     int max = 0;
    //     HashSet<string> set = [];
    //     List<int[]> allEvents = [];

    //     foreach (int[] @event in events)
    //     {
    //         string key = string.Join(",", @event);
    //         if (set.Add(key))
    //         {
    //             allEvents.Add(@event);
    //         }
    //     }
    //     allEvents.Sort((a, b) =>
    //     {
    //         if (a[0] == b[0]) return a[1] - b[1];
    //         return a[0] - b[0];
    //     });

    //     int n = allEvents.Count;
    //     int[] dp = new int[n];
    //     dp[n - 1] = allEvents[n - 1][2];
    //     for (int i = n - 2; i >= 0; i--)
    //     {
    //         dp[i] = Math.Max(allEvents[i][2], dp[i + 1]);
    //     }
    //     for (int i = 0; i < n; i++)
    //     {
    //         max = Math.Max(max, allEvents[i][2]);
    //         int index = BinarySearch(allEvents, allEvents[i][1]);
    //         if (index < i)
    //         {
    //             continue;
    //         }
    //         max = Math.Max(max, allEvents[i][2] + dp[index]);
    //     }
    //     return max;
    // }
    // private int BinarySearch(List<int[]> events, int minStart)
    // {
    //     int left = 0, right = events.Count - 1;
    //     int ans = -1;
    //     while (left <= right)
    //     {
    //         int mid = left + (right - left) / 2;
    //         if (events[mid][0] <= minStart)
    //         {
    //             left = mid + 1;
    //         }
    //         else
    //         {
    //             ans = mid;
    //             right = mid - 1;
    //         }
    //     }
    //     return ans;
    // }
}