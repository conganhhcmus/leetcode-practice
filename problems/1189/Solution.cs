public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        int[] cnt = new int[26];
        foreach (char c in text) cnt[c - 'a']++;
        int ans = int.MaxValue;
        ans = Math.Min(ans, cnt['b' - 'a']);
        ans = Math.Min(ans, cnt['a' - 'a']);
        ans = Math.Min(ans, cnt['l' - 'a'] / 2);
        ans = Math.Min(ans, cnt['o' - 'a'] / 2);
        ans = Math.Min(ans, cnt['n' - 'a']);
        return ans;
    }
}
