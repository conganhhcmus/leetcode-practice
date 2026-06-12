public class Solution
{
    public long LastInteger(long n)
    {
        // n = (n + 1) / 2
        // 1: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
        // 2: [1, 3, 5, 7, 9]
        // 1: [1, 5, 9]
        // 2: [1, 9]
        // 1: [9]
        // ----
        // 1: [1, 2, 3, 4, 5, 6]
        // 2: [1, 3, 5]
        // 1: [1, 5]
        // 2: [1]
        // ----
        // 1: [1, 2, 3, 4, 5, 6, 7, 8]
        // 2: [1, 3, 5, 7]
        // 1: [3, 7]
        // 2: [3]

        long l = 1L, r = n;
        int cnt = 0;
        while (n > 1)
        {
            if ((cnt & 1) == 0)
            {
                // opt1
                if ((n & 1) == 0) r -= 1L << cnt;
            }
            else
            {
                // opt2
                if ((n & 1) == 0) l += 1L << cnt;
            }
            n = (n + 1) >> 1;
            cnt++;
        }
        if ((cnt & 1) == 0) return l;
        return r;
    }
}
