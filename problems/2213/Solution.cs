public class Solution
{
    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
    {
        int k = queryCharacters.Length;
        int[] ans = new int[k];
        int n = s.Length;
        arr = s.ToCharArray();
        tree = new Node[4 * n];
        Build(1, 0, n - 1);
        for (int i = 0; i < k; i++)
        {
            int idx = queryIndices[i];
            char val = queryCharacters[i];
            arr[idx] = val;
            Update(1, 0, n - 1, idx);
            ans[i] = Query(1, 0, n - 1, 0, n - 1);
        }
        return ans;
    }


    class Node(char c)
    {
        public char LeftChar = c;
        public char RightChar = c;

        public int Length = 1;
        public int Prefix = 1;
        public int Suffix = 1;
        public int Max = 1;
    }

    Node[] tree;

    char[] arr;

    void Build(int node, int left, int right)
    {
        if (left == right)
        {
            tree[node] = new Node(arr[left]);
            return;
        }

        int mid = left + (right - left) / 2;
        Build(2 * node, left, mid);
        Build(2 * node + 1, mid + 1, right);
        tree[node] = Merge(tree[2 * node], tree[2 * node + 1]);
    }

    void Update(int node, int left, int right, int idx)
    {
        if (left == right)
        {
            tree[node] = new Node(arr[idx]);
            return;
        }

        int mid = left + (right - left) / 2;
        if (idx <= mid)
        {
            Update(2 * node, left, mid, idx);
        }
        else
        {
            Update(2 * node + 1, mid + 1, right, idx);
        }
        tree[node] = Merge(tree[2 * node], tree[2 * node + 1]);
    }

    Node Merge(Node left, Node right)
    {
        Node result = new(left.LeftChar)
        {
            LeftChar = left.LeftChar,
            RightChar = right.RightChar,
            Length = left.Length + right.Length,

            // default value
            Prefix = left.Prefix,
            Suffix = right.Suffix,
            Max = Math.Max(left.Max, right.Max)
        };

        if (left.RightChar == right.LeftChar)
        {
            result.Max = Math.Max(result.Max, left.Suffix + right.Prefix);

            if (left.Prefix == left.Length)
            {
                result.Prefix = left.Length + right.Prefix;
            }

            if (right.Suffix == right.Length)
            {
                result.Suffix = left.Suffix + right.Length;
            }
        }

        return result;
    }

    int Query(int node, int left, int right, int qLeft, int qRight)
    {
        if (left > qRight || right < qLeft) return 0;
        if (qLeft <= left && qRight >= right) return tree[node].Max;

        int mid = left + (right - left) / 2;
        return Math.Max(Query(2 * node, left, mid, qLeft, qRight), Query(2 * node + 1, mid + 1, right, qLeft, qRight));
    }
}
