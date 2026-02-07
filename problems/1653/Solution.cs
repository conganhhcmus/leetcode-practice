public class Solution
{
    public int MinimumDeletions(string s)
    {
        int n = s.Length;
        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + (s[i] - 'a');
        }
        int ans = n;
        int count = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            ans = Math.Min(ans, count + prefix[i]);
            if (s[i] == 'a') count++;
        }
        return ans;
    }
}