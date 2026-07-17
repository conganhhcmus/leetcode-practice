public class Solution
{
    public long MinimumTime(int[] d, int[] r)
    {
        long INF = 1L << 60;
        long low = 0, high = INF, ans = INF;
        long lcm = LCM(r[0], r[1]);
        long need = d[0] + d[1];
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            if (Ok(mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;

        long LCM(int a, int b)
        {
            return 1L * a * b / GCD(a, b);
        }

        long GCD(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }

        bool Ok(long x)
        {
            long block1 = (x / r[0]) - d[1];
            long block2 = (x / r[1]) - d[0];
            long block12 = x / lcm;

            return x - block12 - Math.Max(0, block1 - block12) - Math.Max(0, block2 - block12) >= need;
        }
    }
}
