public class Solution
{
    public long CountVowels(string word)
    {
        // n = 10^5
        // dp[i] = count vowels end at i
        // dp[i] = if (word[i] is vowels) dp[i-1]+i else dp[i-1]
        int n = word.Length;
        long[] dp = new long[n + 1];
        long ret = 0;
        for (int i = 1; i <= n; i++)
        {
            if (IsVowels(word[i - 1]))
            {
                dp[i] = dp[i - 1] + i;
            }
            else
            {
                dp[i] = dp[i - 1];
            }
            ret += dp[i];
        }
        return ret;
    }

    bool IsVowels(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}