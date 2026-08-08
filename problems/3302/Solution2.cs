public class Solution
{
    public int[] ValidSequence(string word1, string word2)
    {
        int n = word1.Length, m = word2.Length;
        int[] suffix = new int[m];
        Array.Fill(suffix, -1);
        for (int j = m - 1, i = n - 1; j >= 0; j--)
        {
            while (i >= 0 && word1[i] != word2[j]) i--;
            if (i < 0) break;
            suffix[j] = i;
            i--;
        }
        int[] ans = new int[m];
        int p = 0;
        bool used = false;
        for (int i = 0; i < n && p < m; i++)
        {
            if (word1[i] == word2[p])
            {
                ans[p] = i;
                p++;
            }
            else if (!used)
            {
                if (p == m - 1 || suffix[p + 1] > i)
                {
                    ans[p] = i;
                    p++;
                    used = true;
                }
            }
        }
        if (p == m) return ans;
        return [];
    }
}
