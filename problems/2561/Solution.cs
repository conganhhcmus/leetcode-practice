#if DEBUG
namespace Problems_2561;
#endif

public class Solution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        int n = basket1.Length;
        // check can equal
        Dictionary<int, int> freq = [];
        int minCost = int.MaxValue;
        foreach (int cost in basket1)
        {
            freq[cost] = freq.GetValueOrDefault(cost, 0) + 1;
            if (cost < minCost) minCost = cost;
        }
        foreach (int cost in basket2)
        {
            freq[cost] = freq.GetValueOrDefault(cost, 0) + 1;
            if (cost < minCost) minCost = cost;
        }
        foreach (var pair in freq)
        {
            if (pair.Value % 2 != 0) return -1;
            freq[pair.Key] /= 2;
        }
        List<int> needSwap1 = [];
        List<int> needSwap2 = [];
        Dictionary<int, int> tmp = new(freq);
        for (int i = 0; i < n; i++)
        {
            int cost = basket1[i];
            if (tmp[cost] <= 0) needSwap1.Add(basket1[i]);
            tmp[cost]--;
        }
        tmp = new(freq);
        for (int i = 0; i < n; i++)
        {
            int cost = basket2[i];
            if (tmp[cost] <= 0) needSwap2.Add(basket2[i]);
            tmp[cost]--;
        }

        needSwap1.Sort((a, b) => a - b);
        needSwap2.Sort((a, b) => b - a);

        long ans = 0;
        for (int i = 0; i < needSwap1.Count; i++)
        {
            int directSwap = Math.Min(needSwap1[i], needSwap2[i]);
            ans += Math.Min(directSwap, 2 * minCost);
        }

        return ans;
    }
}