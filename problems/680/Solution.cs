public class Solution
{
    public bool ValidPalindrome(string s)
    {
        int n = s.Length;
        int l = 0, r = n - 1;
        return Ok(s, l, r, false);
    }

    bool Ok(string s, int l, int r, bool removed)
    {
        while (l < r)
        {
            if (s[l] == s[r])
            {
                l++;
                r--;
            }
            else
            {
                if (removed) return false;
                return Ok(s, l + 1, r, true) || Ok(s, l, r - 1, true);
            }
        }
        return true;
    }
}