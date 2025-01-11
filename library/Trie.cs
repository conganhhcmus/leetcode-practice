namespace Library;
public class Trie
{
    public class Node
    {
        public int count;
        public Node[] children = new Node[26];
    }

    Node root = new();

    void Insert(string s)
    {
        Node cur = root;
        int len = s.Length;
        for (int i = 0; i < len; ++i)
        {
            int idx = s[i] - 'a';
            if (cur.children[idx] == null) cur.children[idx] = new Node();
            cur.children[idx].count++;
            cur = cur.children[idx];
        }
    }

    int Query(string s)
    {
        Node cur = root;
        int len = s.Length;
        for (int i = 0; i < len; ++i)
        {
            int idx = s[i] - 'a';
            if (cur.children[idx] == null) return 0;
            cur = cur.children[idx];
        }
        return cur.count;
    }
}