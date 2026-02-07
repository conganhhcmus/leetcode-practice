public class Solution
{
    public int MinCost(string colors, int[] neededTime)
    {
        int n = neededTime.Length;
        int ans = 0;
        int maxTime = neededTime[0];
        for (int i = 1; i < n; i++)
        {
            if (colors[i] == colors[i - 1])
            {
                ans += Math.Min(maxTime, neededTime[i]);
                maxTime = Math.Max(maxTime, neededTime[i]);
            }
            else
            {
                maxTime = neededTime[i];
            }
        }
        return ans;
    }
}