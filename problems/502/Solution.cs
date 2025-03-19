#if DEBUG
namespace Problems_502;
#endif

public class Solution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int ans = w;
        Array.Sort(capital, profits);
        PriorityQueue<int, int> pq = new(Comparer<int>.Create((a, b) => b - a));
        int n = profits.Length;
        int curr = 0;
        while (curr < n && k > 0)
        {
            while (curr < n && capital[curr] <= ans)
            {
                pq.Enqueue(profits[curr], profits[curr]);
                curr++;
            }

            if (pq.Count == 0) break;
            ans += pq.Dequeue();
            k--;
        }
        while (k > 0 && pq.Count > 0)
        {
            ans += pq.Dequeue();
            k--;
        }

        return ans;
    }
}