public class Solution
{
    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;
        char[] word = new char[n];
        char curr = 'a';
        for (int i = 0; i < n; i++)
        {
            if (word[i] == '\0')
            {
                if (curr > 'z') return "";
                word[i] = curr;
                for (int j = i + 1; j < n; j++)
                {
                    if (lcp[i][j] > 0)
                    {
                        word[j] = word[i];
                    }
                }
                curr++;
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (word[i] != word[j])
                {
                    if (lcp[i][j] != 0) return "";
                }
                else
                {
                    if (i == n - 1 || j == n - 1)
                    {
                        if (lcp[i][j] != 1) return "";
                    }
                    else
                    {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1) return "";
                    }
                }
            }
        }

        return new string(word);
    }
}