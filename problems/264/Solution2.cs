#if DEBUG
namespace Problems_264_2;
#endif

public class Solution
{
    public int NthUglyNumber(int n)
    {
        HashSet<long> set = [];
        PriorityQueue<long, long> pq = new();
        set.Add(1);
        pq.Enqueue(1, 1);
        long ret = 1;

        while (n > 0)
        {
            ret = pq.Dequeue();
            n--;
            if (set.Add(ret * 2L))
            {
                pq.Enqueue(ret * 2L, ret * 2L);
            }
            if (set.Add(ret * 3L))
            {
                pq.Enqueue(ret * 3L, ret * 3L);
            }
            if (set.Add(ret * 5L))
            {
                pq.Enqueue(ret * 5L, ret * 5L);
            }
        }

        return (int)ret;
    }
}