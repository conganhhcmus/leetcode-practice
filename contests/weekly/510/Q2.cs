public class Solution
{
    public int MinimumCost(int[] nums, int k)
    {
        long cost = 0L;
        int MOD = 1_000_000_007;
        int rem = k;
        long t = 1;
        foreach (int x in nums)
        {
            if (rem < x)
            {
                // rem + c * k >= x
                // c >= (x - rem) / k
                // c = (x - rem + k - 1)/k
                // cost = (t, t + 1, t+2, ..., t+c-1)
                // = c * (2*t + c - 1) / 2
                int c = (x - rem + k - 1) / k;
                rem += c * k;
                cost = (cost + 1L * c * (2 * t + c - 1) / 2 % MOD) % MOD;
                t = (t + c) % MOD;
            }
            rem -= x;
        }

        return (int)cost;
    }
}
