public class Solution
{
    public int[] MinCosts(int[] cost)
    {
        int n = cost.Length;
        int[] ret = new int[n];
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            min = Math.Min(min, cost[i]);
            ret[i] = min;
        }
        return ret;
    }
}