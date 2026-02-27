public class Solution
{
    long INF = long.MaxValue;
    long Ceil(long a, long k) => (a + k - 1) / k;
    public int MinOperations(string s, int k)
    {
        int len = s.Length, zeros = 0;
        foreach (char c in s)
        {
            zeros += '1' - c;
        }

        if (zeros == 0) return 0;
        if (zeros == k) return 1;
        if (k == 1) return zeros;

        if (k == len)
        {
            if (zeros == k) return 1;
            return -1;
        }

        long res = INF;
        if (zeros % 2 == 0)
        {
            long c1 = Ceil(zeros, k), c2 = Ceil(zeros, len - k);
            long m = Math.Max(c1, c2);
            if (m % 2 == 1) m++;

            res = Math.Min(res, (int)m);
        }

        if (zeros % 2 == k % 2)
        {
            long c1 = Ceil(zeros, k), c2 = Ceil(len - zeros, len - k);
            long m = Math.Max(c1, c2);
            if (m % 2 == 0) m++;

            res = Math.Min(res, (int)m);
        }

        return res == INF ? -1 : (int)res;
    }
}