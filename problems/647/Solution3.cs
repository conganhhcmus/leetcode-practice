public class Solution
{
    public int CountSubstrings(string s)
    {
        int n = s.Length;
        int ans = 0;
        // odd-length palindromes
        for (int c = 0; c < n; c++) ans += Expand(c, c);
        // even-length palindromes
        for (int c = 0; c < n - 1; c++) ans += Expand(c, c + 1);
        return ans;

        int Expand(int l, int r)
        {
            int cnt = 0;
            while (l >= 0 && r < n && s[l] == s[r])
            {
                cnt++;
                l--;
                r++;
            }
            return cnt;
        }
    }
}
