public class Solution
{
    public long CountCommas(long n)
    {
        // 1.000 - 999.999
        // 1.000.000 - 999.999.999
        long st = 1000;
        long ed = st * 1000 - 1;
        long count = 0;
        long i = 1;
        while (st <= n)
        {
            count += 1L * i * (Math.Min(n, ed) - st + 1);
            st = st * 1000;
            ed = st * 1000 - 1;
            i++;
        }
        return count;
    }
}