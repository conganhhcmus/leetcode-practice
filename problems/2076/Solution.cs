public class Solution
{
    class UnionFind
    {
        int n;
        int[] parent;

        public UnionFind(int n)
        {
            this.n = n;
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;
            if (x < y)
            {
                parent[y] = x;
            }
            else
            {
                parent[x] = y;
            }
        }
    }

    public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
    {
        int m = requests.Length;
        bool[] ans = new bool[m];

        UnionFind uf = new(n);

        for (int i = 0; i < m; i++)
        {
            int a1 = requests[i][0], b1 = requests[i][1];
            a1 = uf.Find(a1);
            b1 = uf.Find(b1);
            if (a1 > b1) (a1, b1) = (b1, a1);
            bool allow = true;
            foreach (int[] r in restrictions)
            {
                int a2 = r[0], b2 = r[1];
                a2 = uf.Find(a2);
                b2 = uf.Find(b2);
                if (a2 > b2) (a2, b2) = (b2, a2);
                if (a1 == a2 && b1 == b2)
                {
                    allow = false;
                    break;
                }
            }
            if (allow)
            {
                uf.Union(a1, b1);
                ans[i] = true;
            }
        }
        return ans;
    }
}
