public class Solution
{
    public IList<bool> GetResults(int[][] queries)
    {
        List<int> coords = [0];
        List<int> obstacles = [];
        foreach (var q in queries)
        {
            if (q[0] == 1) obstacles.Add(q[1]);
            coords.Add(q[1]);
        }
        List<int> sortedCoords = coords;
        sortedCoords.Sort();

        Dictionary<int, int> map = [];
        for (int i = 0; i < sortedCoords.Count; i++)
        {
            map[sortedCoords[i]] = i;
        }

        Treap treap = new();
        treap.Insert(0);
        foreach (int x in obstacles)
        {
            treap.Insert(x);
        }
        FenwickTree tree = new(sortedCoords.Count);
        List<int> all = [0];
        all.AddRange(obstacles);
        all.Sort();
        for (int i = 1; i < all.Count; i++)
        {
            tree.Update(map[all[i]], all[i] - all[i - 1]);
        }

        List<bool> ans = [];
        for (int qi = queries.Length - 1; qi >= 0; qi--)
        {
            var q = queries[qi];
            if (q[0] == 1)
            {
                int x = q[1];
                int pred = treap.Predecessor(x - 1);
                int succ = treap.Successor(x + 1);
                if (succ != int.MaxValue)
                {
                    tree.Update(map[succ], succ - pred);
                }
                treap.Remove(x);
            }
            else
            {
                int x = q[1];
                int sz = q[2];
                int pred = treap.Predecessor(x);
                int bestGap = Math.Max(tree.Query(map[pred]), x - pred);
                ans.Add(bestGap >= sz);
            }
        }

        ans.Reverse();
        return ans;
    }

    public class FenwickTree
    {
        int[] bit;
        public FenwickTree(int n)
        {
            bit = new int[n + 1];
        }

        public void Update(int idx, int val)
        {
            idx++;
            while (idx < bit.Length)
            {
                bit[idx] = Math.Max(bit[idx], val);
                idx += idx & -idx;
            }
        }

        public int Query(int idx)
        {
            idx++;
            int ans = 0;
            while (idx > 0)
            {
                ans = Math.Max(ans, bit[idx]);
                idx -= idx & -idx;
            }
            return ans;
        }
    }

    public class Treap
    {
        class Node
        {
            public int Val;
            public int Pri;
            public Node Left;
            public Node Right;
            public Node(int val)
            {
                Val = val;
                Pri = Random.Shared.Next();
            }
        }

        Node root;

        public void Insert(int x)
        {
            root = Insert(root, new Node(x));
        }

        Node Insert(Node root, Node node)
        {
            if (root == null) return node;
            if (node.Val < root.Val)
            {
                root.Left = Insert(root.Left, node);
                if (root.Left.Pri > root.Pri)
                {
                    root = RotateRight(root);
                }
            }
            else
            {
                root.Right = Insert(root.Right, node);
                if (root.Right.Pri > root.Pri)
                {
                    root = RotateLeft(root);
                }
            }
            return root;
        }

        public void Remove(int x)
        {
            root = Remove(root, x);
        }

        Node Remove(Node root, int x)
        {
            if (root == null) return null;
            if (x < root.Val)
            {
                root.Left = Remove(root.Left, x);
            }
            else if (x > root.Val)
            {
                root.Right = Remove(root.Right, x);
            }
            else
            {
                if (root.Left == null) return root.Right;
                if (root.Right == null) return root.Left;
                if (root.Left.Pri > root.Right.Pri)
                {
                    root = RotateRight(root);
                    root.Right = Remove(root.Right, x);
                }
                else
                {
                    root = RotateLeft(root);
                    root.Left = Remove(root.Left, x);
                }
            }
            return root;
        }

        public int Predecessor(int x)
        {
            Node cur = root;
            int ans = 0;
            while (cur != null)
            {
                if (cur.Val <= x)
                {
                    ans = cur.Val;
                    cur = cur.Right;
                }
                else
                {
                    cur = cur.Left;
                }
            }
            return ans;
        }

        public int Successor(int x)
        {
            Node cur = root;
            int ans = int.MaxValue;
            while (cur != null)
            {
                if (cur.Val >= x)
                {
                    ans = cur.Val;
                    cur = cur.Left;
                }
                else
                {
                    cur = cur.Right;
                }
            }
            return ans;
        }

        Node RotateRight(Node p)
        {
            Node q = p.Left;
            p.Left = q.Right;
            q.Right = p;
            return q;
        }

        Node RotateLeft(Node p)
        {
            Node q = p.Right;
            p.Right = q.Left;
            q.Left = p;
            return q;
        }
    }

}
