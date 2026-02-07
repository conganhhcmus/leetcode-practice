public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int[] sp = new int[n + 1];
        sp[0] = startTime[0];
        sp[^1] = eventTime - endTime[^1];
        for (int i = 1; i < n; i++)
        {
            sp[i] = startTime[i] - endTime[i - 1];
        }
        PriorityQueue<int, int> pq = new();
        foreach (int val in sp)
        {
            pq.Enqueue(val, -val);
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            // move event[i], space[i] and space[i+1]
            int val = sp[i] + sp[i + 1];
            // check can move to between 2 others, exclude sp[i] and sp[i+1] and endTime[i] - startTime[i]
            int need = endTime[i] - startTime[i];
            List<int> rollBack = [];
            bool can = false;
            Dictionary<int, int> map = [];
            map[sp[i]] = map.GetValueOrDefault(sp[i]) + 1;
            map[sp[i + 1]] = map.GetValueOrDefault(sp[i + 1]) + 1;
            while (pq.Count > 0)
            {
                int curr = pq.Dequeue();
                rollBack.Add(curr);
                if (!map.ContainsKey(curr))
                {
                    if (curr >= need) can = true;
                    break;
                }
                if (map.TryGetValue(curr, out int count))
                {
                    if (count == 1) map.Remove(curr);
                    else map[curr] = count - 1;
                }
            }
            if (can) val += need;
            ans = Math.Max(ans, val);
            foreach (int e in rollBack)
            {
                pq.Enqueue(e, -e);
            }
        }

        return ans;
    }
}