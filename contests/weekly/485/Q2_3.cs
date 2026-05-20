public class Solution
{
    public int MaxCapacity(int[] costs, int[] capacity, int budget)
    {
        int n = costs.Length;
        // top1[c] = largest capacity with exactly costs = c 
        // top2[c] = second largest capacity with exactly costs = c 
        int[] top1 = new int[budget];
        int[] top2 = new int[budget];
        for (int i = 0; i < n; i++)
        {
            int c = costs[i], v = capacity[i];
            if (c >= budget) continue;
            if (v >= top1[c])
            {
                top2[c] = top1[c];
                top1[c] = v;
            }
            else if (v > top2[c])
            {
                top2[c] = v;
            }
        }

        // best[c] = maximum capacity among all costs <= c
        int[] best = new int[budget];
        best[0] = top1[0];
        for (int i = 1; i < budget; i++)
        {
            best[i] = Math.Max(best[i - 1], top1[i]);
        }

        int ans = best[budget - 1];
        for (int i = 0; i < budget; i++)
        {
            if (i * 2 < budget)
            {
                ans = Math.Max(ans, top1[i] + top2[i]);
            }
            // find j with costs[j] + costs[i] < budget and j < i
            int j = Math.Max(0, Math.Min(i - 1, budget - 1 - i));
            ans = Math.Max(ans, best[j] + top1[i]);
        }
        return ans;
    }
}
