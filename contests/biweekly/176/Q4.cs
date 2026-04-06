public class Solution
{
    int N, T; // length, time
    int[] H, I, O, B; // height, in, out, fenwick tree

    int[][] P; // parent
    char[] C; // character arr
    List<int>[] G; // graph list

    public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
    {
        N = n;
        T = 0;
        P = new int[n][];
        H = new int[n];
        C = new char[n];
        I = new int[n + 1];
        O = new int[n + 1];
        G = new List<int>[n];
        B = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            P[i] = new int[18];
            G[i] = [];
            C[i] = s[i];
        }

        foreach (int[] e in edges)
        {
            G[e[0]].Add(e[1]);
            G[e[1]].Add(e[0]);
        }

        void DFS(int c, int p, int h)
        {
            I[c] = ++T;
            H[c] = h;
            P[c][0] = p;
            for (int i = 1; i < 18; i++)
            {
                P[c][i] = P[P[c][i - 1]][i - 1];
            }
            foreach (int n in G[c])
            {
                if (n != p)
                {
                    DFS(n, c, h + 1);
                }
            }
            O[c] = T;
        }

        void Update(int i, int v)
        {
            for (; i <= N; i += i & -i)
            {
                B[i] ^= v;
            }
        }

        int Query(int i)
        {
            int s = 0;
            for (; i > 0; i -= i & -i)
            {
                s ^= B[i];
            }
            return s;
        }

        int LCA(int u, int v)
        {
            if (H[u] < H[v]) (u, v) = (v, u);
            for (int i = 17; i >= 0; i--)
            {
                if (H[u] - (1 << i) >= H[v])
                {
                    u = P[u][i];
                }
            }
            if (u == v) return v;
            for (int i = 17; i >= 0; i--)
            {
                if (P[u][i] != P[v][i])
                {
                    u = P[u][i];
                    v = P[v][i];
                }
            }
            return P[u][0];
        }

        DFS(0, 0, 0);

        for (int i = 0; i < n; i++)
        {
            int v = 1 << (C[i] - 'a');
            Update(I[i], v);
            Update(O[i] + 1, v);
        }

        IList<bool> ans = [];
        foreach (string q in queries)
        {
            string[] a = q.Split(" ");
            if (a[0] == "update")
            {
                int u = int.Parse(a[1]);
                char c = char.Parse(a[2]);
                int v = (1 << (c - 'a')) ^ (1 << (C[u] - 'a'));
                Update(I[u], v);
                Update(O[u] + 1, v);
                C[u] = c;
            }
            else
            {
                int u = int.Parse(a[1]);
                int v = int.Parse(a[2]);
                int m = Query(I[u]) ^ Query(I[v]) ^ (1 << (C[LCA(u, v)] - 'a'));
                ans.Add((m & (m - 1)) == 0);
            }
        }
        return ans;
    }
}