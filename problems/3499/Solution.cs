public class Solution
{
    public int MaxActiveSectionsAfterTrade(string s)
    {
        int n = s.Length;
        // cover 1 -> 0, then 0 -> 1
        // cnt 0 - 1 - 0
        List<int> zeros = [];
        int cnt = 1;
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == s[i - 1]) cnt++;
            else
            {
                if (s[i] == '1') zeros.Add(cnt);
                else sum += cnt;
                cnt = 1;
            }
        }
        if (s[n - 1] == '1') sum += cnt;
        else zeros.Add(cnt);
        int ans = sum;
        for (int i = 1; i < zeros.Count; i++)
        {
            ans = Math.Max(ans, sum + zeros[i - 1] + zeros[i]);
        }
        return ans;
    }
}
