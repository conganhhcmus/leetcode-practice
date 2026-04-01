public class Solution
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        int n = tickets.Length;
        int ans = 0;
        for (int i = 0; i <= k; i++)
        {
            ans += Math.Min(tickets[i], tickets[k]);
        }
        for (int i = k + 1; i < n; i++)
        {
            ans += Math.Min(tickets[i], tickets[k] - 1);
        }
        return ans;
    }
}