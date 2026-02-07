public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int[] dp = new int[s.Length + 1];

        for (int i = 0; i < s.Length; i++)
        {
            dp[i + 1] = dp[i] + ((s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u') ? 1 : 0);
        }

        int ans = 0;

        for (int i = 0; i + k <= s.Length; i++)
        {
            ans = Math.Max(ans, dp[i + k] - dp[i]);
        }

        return ans;
    }
}