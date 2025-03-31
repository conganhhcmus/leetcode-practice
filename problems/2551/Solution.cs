#if DEBUG
namespace Problems_2551;
#endif

public class Solution
{
    public long PutMarbles(int[] weights, int k)
    {
        int n = weights.Length;
        PriorityQueue<long, long> minHeap = new();
        PriorityQueue<long, long> maxHeap = new();
        for (int i = 1; i < n; i++)
        {
            long value = weights[i] + weights[i - 1];
            minHeap.Enqueue(value, value);
            maxHeap.Enqueue(value, -value);
        }
        long ret = 0;
        for (int i = 0; i < k - 1; i++)
        {
            ret += maxHeap.Dequeue() - minHeap.Dequeue();
        }
        return ret;
    }
}