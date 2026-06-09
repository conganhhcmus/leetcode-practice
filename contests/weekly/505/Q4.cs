public class Solution
{
    public long MaximumSum(int[] nums, int m, int l, int r)
    {
        long INF = 1L << 60;
        int n = nums.Length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + nums[i];
        var (sum0, cnt0) = Solve(0);
        if (cnt0 == 0) return Solve1();
        if (cnt0 <= m) return sum0;
        long low = 0, high = INF;
        long ans = 0L;
        // F(c) = V(t) - c * t
        // F(c) + c * m = V(t) + c * m - c * t 
        // F(c) + c * m = V(t) + c * (m - t)
        // F(c) + c * m <= V(t) where t >= m
        // V(t) is the answer = F(c) + c * m
        // c is larger => t is smaller
        // t in range [0..m]
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            var (sum, cnt) = Solve(mid);
            if (cnt >= m)
            {
                ans = sum + mid * m;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;

        long Solve1()
        {
            int[] dq = new int[n + 1];
            int tail = 0, head = 0;
            long ans = -INF;
            for (int i = 1; i <= n; i++)
            {
                int L = i - r;
                int R = i - l;
                if (R >= 0)
                {
                    while (head < tail && pref[R] <= pref[dq[tail - 1]]) tail--;
                    dq[tail++] = R;
                }
                while (head < tail && dq[head] < L) head++;
                if (head < tail)
                {
                    int best = dq[head];
                    long val = pref[i] - pref[best];
                    if (ans < val) ans = val;
                }
            }
            return ans;
        }

        (long sum, long cnt) Solve(long cost)
        {
            long[] dp = new long[n + 1];
            long[] cnt = new long[n + 1];
            int[] dq = new int[n + 1];
            int tail = 0, head = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = dp[i - 1];
                cnt[i] = cnt[i - 1];
                if (i >= l)
                {
                    int j = i - l;
                    long valJ = dp[j] - pref[j];
                    long cntJ = cnt[j];
                    while (head < tail)
                    {
                        int back = dq[tail - 1];
                        long valBack = dp[back] - pref[back];
                        long cntBack = cnt[back];
                        if (valJ > valBack || (valJ == valBack && cntJ > cntBack)) tail--;
                        else break;
                    }
                    dq[tail++] = j;
                }

                while (head < tail && dq[head] < i - r) head++;
                if (head < tail)
                {
                    int bestJ = dq[head];
                    long valJ = dp[bestJ] + pref[i] - pref[bestJ] - cost;
                    long cntJ = cnt[bestJ] + 1;
                    if (valJ > dp[i] || (valJ == dp[i] && cntJ > cnt[i]))
                    {
                        dp[i] = valJ;
                        cnt[i] = cntJ;
                    }
                }
            }

            return (dp[n], cnt[n]);
        }
    }
}
