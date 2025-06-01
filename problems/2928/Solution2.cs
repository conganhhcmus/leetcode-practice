#if DEBUG
namespace Problems_2928_2;
#endif

public class Solution
{
    public int DistributeCandies(int n, int limit)
    {
        int ways = 0;
        if (3 * limit < n) return 0;
        if (3 * limit == n) return 1;
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