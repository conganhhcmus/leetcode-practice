public class Solution
{
    public int MaxCapacity(int[] costs, int[] capacity, int budget)
    {
        int n = costs.Length;
        Array.Sort(costs, capacity);
        int[] prefix = new int[n];
        prefix[0] = capacity[0];
        for (int i = 1; i < n; i++)
        {
            prefix[i] = Math.Max(prefix[i - 1], capacity[i]);
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int rem = budget - costs[i];
            if (rem <= 0) break;
            int low = 0, high = i - 1, best = 0;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (costs[mid] < rem)
                {
                    best = prefix[mid];
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            ans = Math.Max(ans, capacity[i] + best);
        }
        return ans;
    }
}
