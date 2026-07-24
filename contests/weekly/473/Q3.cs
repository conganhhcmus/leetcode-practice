public class Solution
{
    public long CountStableSubarrays(int[] capacity)
    {
        int n = capacity.Length;
        // s[l] == s[r] == sum [l+1..r-1]
        // sum [l..r] / 3 = target
        // key = (s[i], bal)
        // cur - bal = 3 * s[i]
        // bal = cur - 3 * s[i]
        Dictionary<(int, long), int> cnt = [];
        long ans = 0;
        long sum1 = 0, sum2 = 0;
        for (int i = 0, j = 0; i < n; i++)
        {
            sum1 += capacity[i];
            long need = sum1 - 2L * capacity[i];
            ans += cnt.GetValueOrDefault((capacity[i], need), 0);
            if (i - j >= 1)
            {
                sum2 += capacity[j];
                cnt[(capacity[j], sum2)] = cnt.GetValueOrDefault((capacity[j], sum2), 0) + 1;
                j++;
            }
        }
        return ans;
    }
}
