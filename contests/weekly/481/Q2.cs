public class Solution
{
    public long MinCost(string s, int[] cost)
    {
        int n = s.Length;
        long[] saved = new long[26];
        long total = 0L;
        for (int i = 0; i < n; i++)
        {
            total += cost[i];
            saved[s[i] - 'a'] += cost[i];
        }
        long ans = 1L << 60;
        for (int i = 0; i < 26; i++)
        {
            ans = Math.Min(ans, total - saved[i]);
        }
        return ans;
    }
}
