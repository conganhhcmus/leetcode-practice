public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> pq = new();
        foreach (int st in stones)
        {
            pq.Enqueue(st, -st);
        }
        while (pq.Count > 1)
        {
            int p = pq.Dequeue();
            int q = pq.Dequeue();
            if (p == q) continue;
            int r = p - q;
            pq.Enqueue(r, -r);
        }
        if (pq.Count == 0) return 0;
        return pq.Dequeue();
    }
}