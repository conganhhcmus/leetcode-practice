public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        Trie root = new();
        foreach (int num in arr1)
        {
            root.Add(num);
        }
        int ans = 0;
        foreach (int num in arr2)
        {
            ans = Math.Max(ans, root.Query(num));
        }
        return ans;
    }

    public class Trie
    {
        public Trie[] child = new Trie[10];

        public void Add(int num)
        {
            string s = num.ToString();
            Trie cur = this;
            foreach (char c in s)
            {
                int idx = c - '0';
                if (cur.child[idx] == null) cur.child[idx] = new();
                cur = cur.child[idx];
            }
        }

        public int Query(int num)
        {
            string s = num.ToString();
            int len = 0;
            Trie cur = this;
            foreach (char c in s)
            {
                int idx = c - '0';
                if (cur.child[idx] == null) break;
                len++;
                cur = cur.child[idx];
            }

            return len;
        }
    }
}
