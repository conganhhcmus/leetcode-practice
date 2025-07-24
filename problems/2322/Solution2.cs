#if DEBUG
namespace Problems_2322_2;
#endif

public class Solution
{
    public int MinimumScore(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = [];
        }
        foreach (int[] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int[] sum = new int[n];
        int[] in_ = new int[n];
        int[] out_ = new int[n];
        int count = 0;

        void DFS(int u, int p)
        {
            in_[u] = count++;
            sum[u] = nums[u];
            foreach (int v in adj[u])
            {
                if (v == p) continue;
                DFS(v, u);
                sum[u] ^= sum[v];
            }
            out_[u] = count;
        }

        int ans = int.MaxValue;
        DFS(0, -1);

        for (int u = 1; u < n; u++)
        {
            for (int v = u + 1; v < n; v++)
            {
                if (in_[v] > in_[u] && in_[v] < out_[u])
                {
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                }
                else if (in_[u] > in_[v] && in_[u] < out_[v])
                {
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                }
                else
                {
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
                }
            }
        }

        return ans;
    }

    int Calc(int part1, int part2, int part3)
    {
        return Math.Max(part1, Math.Max(part2, part3)) -
               Math.Min(part1, Math.Min(part2, part3));
    }
}