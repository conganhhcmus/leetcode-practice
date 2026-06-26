public class Solution
{
    public int MinLengthAfterRemovals(string s)
    {
        int n = s.Length;
        int[] dp = new int[n + 1];
        Dictionary<int, int> map = [];
        int bal = 0;
        map[0] = 0;
        for (int i = 0; i < n; i++)
        {
            dp[i + 1] = dp[i];
            if (s[i] == 'a') bal++;
            else bal--;
            if (map.TryGetValue(bal, out int j))
            {
                dp[i + 1] = Math.Max(dp[i + 1], dp[j] + i - j + 1);
            }
            map[bal] = i + 1;
        }

        return n - dp[n];
    }
}
