public class Solution
{
    public int CountLargestGroup(int n)
    {
        int[] map = new int[37];
        int[] dp = new int[n + 1];
        // dp[i] : sum of digit of i. i = 13 = 1+3 = 4
        // dp[i] = dp[i/10] + i % 10

        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i / 10] + (i % 10);
            map[dp[i]]++;
        }

        int ret = 0, max = 0;
        foreach (int freq in map)
        {
            if (max < freq) max = freq;
        }

        foreach (int freq in map)
        {
            if (freq == max) ret++;
        }
        return ret;
    }
}