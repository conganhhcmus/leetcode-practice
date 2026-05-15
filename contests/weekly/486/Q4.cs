public class Solution
{
    public long NthSmallest(long n, int k)
    {
        int MAX = 55;
        long[,] C = new long[MAX, MAX];
        for (int i = 0; i < MAX; i++)
        {
            C[i, 0] = C[i, i] = 1;
            for (int j = 1; j < i; j++)
            {
                C[i, j] = C[i - 1, j] + C[i - 1, j - 1];
            }
        }
        long ans = 0L;
        int remain = k;
        for (int bit = MAX - 1; bit >= 0; bit--)
        {
            if (remain == 0) break;
            long cnt = C[bit, remain];
            if (cnt < n)
            {
                n -= cnt;
                remain--;
                ans |= 1L << bit;
            }
        }
        return ans;
    }
}
