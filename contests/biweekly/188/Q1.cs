public class Solution
{
    public int CountValidPrefixes(string s)
    {
        int bal = 0;
        int ans = 0;
        foreach (char c in s)
        {
            if (c == '1') bal++;
            else bal--;
            if (Math.Abs(bal) < 2) ans++;
        }
        return ans;
    }
}
