public class Solution
{
    public string LongestPrefix(string s)
    {
        int n = s.Length;
        int[] lsp = new int[n];
        int j = 0;
        int i = 1;
        while (i < n)
        {
            if (s[i] == s[j])
            {
                j++;
                lsp[i] = j;
                i++;
            }
            else
            {
                if (j != 0)
                {
                    j = lsp[j - 1];
                }
                else
                {
                    lsp[j] = 0;
                    i++;
                }
            }
        }
        return s.Substring(0, lsp[n - 1]);
    }
}
