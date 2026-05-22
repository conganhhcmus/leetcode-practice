public class Solution
{
    public IList<int> MinimumFlips(int n, int[][] edges, string start, string target)
    {
        List<(int v, int i)>[] adj = new List<(int v, int i)>[n];
        for (int i = 0; i < n; i++) adj[i] = [];
        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0], v = edges[i][1];
            adj[u].Add((v, i));
            adj[v].Add((u, i));
        }
        int[] diff = new int[n];
        for (int i = 0; i < n; i++)
        {
            diff[i] = (start[i] - '0') ^ (target[i] - '0');
        }
        List<int> ans = [];
        bool[] visited = new bool[n];

        int rootNeed = Dfs(0);
        if (rootNeed == 1) return [-1];
        ans.Sort();
        return ans;

        int Dfs(int u)
        {
            visited[u] = true;
            int need = diff[u];
            foreach (var (v, i) in adj[u])
            {
                if (visited[v]) continue;
                int childNeed = Dfs(v);
                if (childNeed == 1)
                {
                    ans.Add(i);
                    need ^= 1;
                }
            }
            return need;
        }
    }
}
