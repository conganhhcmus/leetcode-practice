public class Solution
{
    public int MaxDepth(string s)
    {
        int bal = 0;
        int ans = 0;
        foreach (char c in s)
        {
            if (c == '(') bal++;
            if (c == ')') bal--;
            ans = Math.Max(ans, bal);
        }
        return ans;
    }
}