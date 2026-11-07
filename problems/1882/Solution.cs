public class Solution
{
    public int[] AssignTasks(int[] servers, int[] tasks)
    {
        int n = servers.Length, m = tasks.Length;
        PriorityQueue<int, (int val, int idx)> free = new();
        for (int i = 0; i < n; i++) free.Enqueue(i, (servers[i], i));
        PriorityQueue<int, long> delay = new();
        int[] ans = new int[m];
        long t = 0;
        for (int k = 0; k < m; k++)
        {
            t = Math.Max(t, k);

            while (delay.TryPeek(out int idx, out long endTime) && endTime <= t)
            {
                delay.Dequeue();
                free.Enqueue(idx, (servers[idx], idx));
            }

            if (free.Count == 0)
            {
                delay.TryPeek(out _, out long nextTime);
                t = nextTime;
                while (delay.TryPeek(out int idx, out long endTime) && endTime <= t)
                {
                    delay.Dequeue();
                    free.Enqueue(idx, (servers[idx], idx));
                }
            }
            int x = free.Dequeue();
            ans[k] = x;
            delay.Enqueue(x, t + tasks[k]);
        }
        return ans;
    }
}