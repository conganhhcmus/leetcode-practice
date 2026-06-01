public class Solution
{
    public int MaximumSaleItems(int[][] items, int budget)
    {
        int n = items.Length;
        int[] count = new int[n + 1];
        int minCost = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int factor = items[i][0];
            int cost = items[i][1];
            if (cost < minCost) minCost = cost;
            for (int j = 1; j * j <= factor; j++)
            {
                if (factor % j == 0)
                {
                    count[j]++;
                    if (j * j != factor) count[factor / j]++;
                }
            }
        }

        int ans = 0;
        Array.Sort(items, (a, b) => a[1] - b[1]);
        for (int i = 0; i < n; i++)
        {
            int factor = items[i][0];
            int cost = items[i][1];
            if (cost < 2 * minCost && count[factor] > 1)
            {
                int take = Math.Min(count[factor] - 1, budget / cost);
                ans += 2 * take;
                budget -= take * cost;
            }
        }
        ans += budget / minCost;
        return ans;
    }
}
