public class Solution
{
    public int FillCups(int[] amount)
    {
        PriorityQueue<int, int> pq = new();
        foreach (int val in amount) pq.Enqueue(val, -val);
        int ret = 0;
        while (pq.Count > 0)
        {
            int max1 = pq.Dequeue();
            int max2 = pq.Dequeue();
            if (max1 == 0) break;
            ret++;
            pq.Enqueue(max1 - 1, 1 - max1);
            pq.Enqueue(max2 - 1, 1 - max2);
        }

        return ret;
    }
}