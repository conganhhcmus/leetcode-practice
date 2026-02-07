public class Solution
{
    public int DistributeCandies(int n, int limit)
    {
        int ways = 0;
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n - i; j++)
            {
                int k = n - i - j;
                if (i + j + k == n && i <= limit && j <= limit && k <= limit) ways++;
            }
        }

        return ways;
    }
}