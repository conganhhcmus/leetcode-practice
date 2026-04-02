public class Solution
{
    public bool IsPossible(int[] target)
    {
        PriorityQueue<long, long> pq = new();
        long sum = 0;
        foreach (int t in target)
        {
            pq.Enqueue(t, -t);
            sum += t;
        }
        while (pq.Count > 0)
        {
            long max = pq.Dequeue();
            // sum = other + max
            // max = other + val
            // val = max - other
            // other = sum - max
            long other = sum - max;
            if (max == 1 || other == 1) return true;
            if (other == 0 || other >= max) return false;
            long val = max % other;
            if (val == 0 || val == max) return false;
            pq.Enqueue(val, -val);
            sum = val + other;
        }

        return true;
    }
}