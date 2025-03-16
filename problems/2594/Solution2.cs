#if DEBUG
namespace Problems_2594_2;
#endif

public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        Dictionary<int, int> map = [];
        for (int i = 0; i < ranks.Length; i++)
        {
            map[ranks[i]] = map.GetValueOrDefault(ranks[i], 0) + 1;
        }
        PriorityQueue<(int rank, int dup, int number, long time), long> pq = new();
        foreach (int rank in map.Keys)
        {
            pq.Enqueue((rank, map[rank], 1, 1L * rank), 1 * rank);
        }
        long ans = 0;
        while (cars > 0)
        {
            var (rank, dup, number, time) = pq.Dequeue();
            ans = time;
            cars -= dup;
            int newNumber = number + 1;
            long newTime = 1L * rank * newNumber * newNumber;
            pq.Enqueue((rank, dup, newNumber, newTime), newTime);
        }

        return ans;
    }
}