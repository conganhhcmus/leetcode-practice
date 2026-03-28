public class Solution
{
    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;
        int[] parent = new int[n];

        for (int i = 0; i < n; i++) parent[i] = i;

        int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        void Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);
            if (a != b) parent[b] = a;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (lcp[i][j] > 0)
                {
                    Union(i, j);
                }
            }
        }

        char[] word = new char[n];
        Dictionary<int, char> map = [];
        char c = 'a';

        for (int i = 0; i < n; i++)
        {
            int p = Find(i);
            if (!map.ContainsKey(p))
            {
                if (c > 'z') return "";
                map[p] = c++;
            }
            word[i] = map[p];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int v = (word[i] == word[j]) ? (1 + ((i + 1 < n && j + 1 < n) ? lcp[i + 1][j + 1] : 0)) : 0;
                if (lcp[i][j] != v) return "";
            }
        }

        return new string(word);
    }
}