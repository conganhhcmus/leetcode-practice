public class Solution
{
    public int MaxEvents(int[][] events)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);
        PriorityQueue<int, int> pq = new();
        int maxDay = events.Max(e => e[1]);
        int n = events.Length;
        int ans = 0;
        for (int i = 1, j = 0; i <= maxDay; i++)
        {
            while (j < n && events[j][0] <= i)
            {
                pq.Enqueue(events[j][1], events[j][1]);
                j++;
            }
            while (pq.Count > 0 && pq.Peek() < i)
            {
                pq.Dequeue();
            }
            if (pq.Count > 0)
            {
                ans++;
                pq.Dequeue();
            }
        }
        return ans;
    }
}