public class Solution
{
    public long DistributeCandies(int n, int limit)
    {
        if (n > 3 * limit) return 0;
        long ways = Comb2(n + 2);
        if (n >= (limit + 1))
        {
            ways -= 3 * Comb2(n - (limit + 1) + 2);
        }
        if (n >= 2 * (limit + 1))
        {
            ways += 3 * Comb2(n - 2 * (limit + 1) + 2);
        }

        return ways;
    }

    long Comb2(int n)
    {
        return 1L * n * (n - 1) / 2;
    }
}