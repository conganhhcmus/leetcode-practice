public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        PriorityQueue<(int, int, long), long> pq = new();
        foreach (int wt in workerTimes)
        {
            pq.Enqueue((wt, 1, wt), wt);
        }
        long ans = 0;
        while (mountainHeight > 0)
        {
            var (wt, h, t) = pq.Dequeue();
            ans = Math.Max(ans, t);
            h++;
            long nt = 1L * h * (h + 1) / 2 * wt;
            pq.Enqueue((wt, h, nt), nt);
            mountainHeight--;
        }

        return ans;
    }
}