public class Solution
{
    public string GetHappyString(int n, int k)
    {
        char[] chars = ['a', 'b', 'c'];
        return BackTracking(n, ref k, "", chars);
    }

    private string BackTracking(int n, ref int k, string curr, char[] chars)
    {
        if (n == 0)
        {
            if (--k == 0) return curr;
            return string.Empty;
        }

        foreach (char c in chars)
        {
            if (curr.Length > 0 && curr[^1] == c) continue;
            string ans = BackTracking(n - 1, ref k, curr + c, chars);
            if (!string.IsNullOrEmpty(ans)) return ans;
        }
        return string.Empty;
    }
}