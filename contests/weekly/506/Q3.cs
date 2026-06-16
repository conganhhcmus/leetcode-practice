public class Solution
{
    public long MaxRatings(int[][] units)
    {
        int m = units.Length, n = units[0].Length;
        if (n == 1)
        {
            long sum = 0L;
            for (int i = 0; i < m; i++) sum += units[i][0];
            return sum;
        }
        long ans = 0L;
        long globalMin1 = long.MaxValue;
        long globalMin2 = long.MaxValue;
        for (int i = 0; i < m; i++)
        {
            long min1 = long.MaxValue;
            long min2 = long.MaxValue;
            foreach (int x in units[i])
            {
                if (x < min1)
                {
                    min2 = min1;
                    min1 = x;
                }
                else if (x < min2)
                {
                    min2 = x;
                }
            }
            globalMin1 = Math.Min(globalMin1, min1);
            globalMin2 = Math.Min(globalMin2, min2);
            ans += min2;
        }
        ans += globalMin1 - globalMin2;
        return ans;
    }
}
