public class Solution
{
    public long DistributeCandies(int n, int limit)
    {
        if (3 * limit < n) return 0;
        if (3 * limit == n) return 1;
        long ways = 0;
        for (int i = Math.Max(0, n - 2 * limit); i <= Math.Min(n, limit); i++)
        {
            int remain = n - i;
            int min = Math.Max(0, remain - limit);
            int max = Math.Min(remain, limit);
            ways += max - min + 1;
        }
        return ways;
    }
}