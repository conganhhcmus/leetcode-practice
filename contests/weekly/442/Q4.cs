public class Solution
{
    public long MinOperations(int[][] queries)
    {
        long ans = 0;
        foreach (int[] query in queries)
        {
            int l = query[0], r = query[1];
            ans += (MinPerform(r) - MinPerform(l - 1) + 1L) / 2;
        }
        return ans;
    }

    long MinPerform(int n)
    {
        // 1 2 3 ... n
        // t = 1 count all elements > 1
        // t = 4 count all elements > 4
        // t = 16 count all elements > 16
        //...
        long ret = 0;
        long t = 1;
        while (n - t + 1 > 0)
        {
            ret += Math.Max(n - t + 1, 0);
            t *= 4;
        }
        return ret;
    }
}