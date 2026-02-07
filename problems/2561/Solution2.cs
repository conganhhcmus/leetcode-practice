public class Solution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        Dictionary<int, int> freq = [];
        int minCost = int.MaxValue;
        foreach (int cost in basket1)
        {
            freq[cost] = freq.GetValueOrDefault(cost, 0) + 1;
            minCost = Math.Min(minCost, cost);
        }
        foreach (int cost in basket2)
        {
            freq[cost] = freq.GetValueOrDefault(cost, 0) - 1;
            minCost = Math.Min(minCost, cost);
        }
        List<int> merge = [];
        foreach (var pair in freq)
        {
            if (pair.Value % 2 != 0) return -1;
            for (int i = 0; i < Math.Abs(pair.Value) / 2; i++)
            {
                merge.Add(pair.Key);
            }
        }
        merge.Sort();
        long ans = 0;
        for (int i = 0; i < merge.Count / 2; i++)
        {
            ans += Math.Min(2 * minCost, merge[i]);
        }
        return ans;
    }
}