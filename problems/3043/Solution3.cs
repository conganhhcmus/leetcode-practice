public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        Trie root1 = new();
        Trie root2 = new();
        foreach (int num in arr1)
        {
            Add(root1, num);
        }
        foreach (int num in arr2)
        {
            Add(root2, num);
        }

        return Dfs(root1, root2) - 1;
    }

    public class Trie
    {
        public Trie[] child = new Trie[10];
    }

    void Add(Trie root, int num)
    {
        Trie cur = root;
        string s = num.ToString();
        foreach (char c in s)
        {
            int idx = c - '0';
            if (cur.child[idx] == null)
            {
                cur.child[idx] = new();
            }
            cur = cur.child[idx];
        }
    }

    int Dfs(Trie root1, Trie root2)
    {
        if (root1 == null || root2 == null) return 0;
        int ans = 0;
        for (int i = 0; i < 10; i++)
        {
            ans = Math.Max(ans, 1 + Dfs(root1.child[i], root2.child[i]));
        }

        return ans;
    }
}
