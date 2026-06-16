public class Solution
{
    public long MinMoves(int[] balance)
    {
        int n = balance.Length;
        int pos = 0;
        for (int i = 0; i < balance.Length; i++)
        {
            if (balance[i] < 0) pos = i;
        }
        long ans = 0L;
        int val = -balance[pos];
        for (int i = 1; i <= n / 2; i++)
        {
            int l = (pos - i + n) % n;
            int r = (pos + i + n) % n;
            int moves = Math.Max(0, Math.Min(val, balance[l]));
            ans += 1L * moves * i;
            val -= moves;
            if (r != l)
            {
                moves = Math.Max(0, Math.Min(val, balance[r]));
                ans += 1L * moves * i;
                val -= moves;
            }
        }
        if (val <= 0) return ans;
        return -1;
    }
}
