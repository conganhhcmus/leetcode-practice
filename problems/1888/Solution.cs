public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        int ans = int.MaxValue;
        int cnt = 0;
        // even is '0', odd is '1'
        int turn = 0;
        for (int i = 0; i < n; i++)
        {
            cnt += (s[i] == '0' + i % 2) ? 0 : 1;
        }
        ans = Math.Min(ans, Math.Min(cnt, n - cnt));
        s += s;
        for (int i = n; i < 2 * n; i++)
        {
            cnt -= (s[i - n] == '0' + (i - n) % 2) ? 0 : 1;
            cnt += (s[i] == '0' + i % 2) ? 0 : 1;
            ans = Math.Min(ans, Math.Min(cnt, n - cnt));
        }

        return ans;
    }
}