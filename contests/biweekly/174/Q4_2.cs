public class Solution
{
    public IList<int> MinimumFlips(int n, int[][] edges, string start, string target)
    {
        int[] diff = new int[n];
        for (int i = 0; i < n; i++)
        {
            diff[i] = start[i] == target[i] ? 0 : 1;
        }
        List<(int, int)>[] g = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        for (int i = 0; i < n - 1; i++)
        {
            int u = edges[i][0], v = edges[i][1];
            g[u].Add((v, i));
            g[v].Add((u, i));
        }

        int[] parent = new int[n];
        int[] parentEdge = new int[n];
        Array.Fill(parent, -1);
        parent[0] = 0;
        List<int> order = [];
        Stack<int> st = [];
        st.Push(0);
        while (st.Count > 0)
        {
            int u = st.Pop();
            order.Add(u);
            foreach (var (v, i) in g[u])
            {
                if (parent[v] != -1) continue;
                parent[v] = u;
                parentEdge[v] = i;
                st.Push(v);
            }
        }
        List<int> ans = [];

        for (int i = order.Count - 1; i > 0; i--)
        {
            int u = order[i];
            if (diff[u] == 1)
            {
                ans.Add(parentEdge[u]);
                diff[parent[u]] ^= 1;
            }
        }

        if (diff[0] != 0) return [-1];
        ans.Sort();
        return ans;
    }
}
