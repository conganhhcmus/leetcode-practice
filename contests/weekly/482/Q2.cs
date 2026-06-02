public class Solution
{
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2)
    {
        int pairs = Math.Min(need1, need2);
        int costPairs = Math.Min(cost1 + cost2, costBoth);
        need1 -= pairs;
        need2 -= pairs;
        long ans = 1L * pairs * costPairs;
        ans += 1L * need1 * Math.Min(cost1, costBoth);
        ans += 1L * need2 * Math.Min(cost2, costBoth);

        return ans;
    }
}
