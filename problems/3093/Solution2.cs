public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        int n = wordsContainer.Length, m = wordsQuery.Length;
        long M1 = (long)1e9 + 7;
        long M2 = (long)1e9 + 9;
        long B1 = 29;
        long B2 = 31;
        Dictionary<(long, long), int> map = [];
        map[(0, 0)] = 0;
        for (int i = 0; i < n; i++)
        {
            string w = wordsContainer[i];
            long h1 = 0, h2 = 0;
            if (map.ContainsKey((h1, h2)) == false || w.Length < wordsContainer[map[(h1, h2)]].Length)
            {
                map[(h1, h2)] = i;
            }
            for (int j = w.Length - 1; j >= 0; j--)
            {
                int v = w[j] - 'a' + 1;
                h1 = (h1 * B1 + v) % M1;
                h2 = (h2 * B2 + v) % M2;
                if (map.ContainsKey((h1, h2)) == false || w.Length < wordsContainer[map[(h1, h2)]].Length)
                {
                    map[(h1, h2)] = i;
                }
            }
        }
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            string w = wordsQuery[i];
            long h1 = 0, h2 = 0;
            ans[i] = map[(h1, h2)];
            for (int j = w.Length - 1; j >= 0; j--)
            {
                int v = w[j] - 'a' + 1;
                h1 = (h1 * B1 + v) % M1;
                h2 = (h2 * B2 + v) % M2;
                if (map.ContainsKey((h1, h2)))
                {
                    ans[i] = map[(h1, h2)];
                }
            }
        }
        return ans;
    }
}
