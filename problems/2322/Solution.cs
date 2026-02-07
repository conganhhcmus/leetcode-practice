public class Solution
{
    public int MinimumScore(int[] nums, int[][] edges)
    {
        int totalXor = 0;
        int ans = int.MaxValue;

        foreach (int num in nums)
        {
            totalXor ^= num;
        }

        int n = nums.Length;
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = [];
        }

        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        int DFS(int u, int p)
        {
            int xor = nums[u];
            foreach (int v in adj[u])
            {
                if (v == p) continue;
                xor ^= DFS(v, u);
            }

            foreach (int v in adj[u])
            {
                if (v == p)
                {
                    DFS2(v, u, u, xor);
                }
            }
            return xor;
        }

        int DFS2(int u, int p, int r, int otherXor)
        {
            int xor = nums[u];
            foreach (int v in adj[u])
            {
                if (v == p) continue;
                xor ^= DFS2(v, u, r, otherXor);
            }
            if (p == r) return xor;
            ans = Math.Min(ans, Calc(otherXor, xor, totalXor ^ otherXor ^ xor));
            return xor;
        }

        DFS(0, -1);

        return ans;
    }

    int Calc(int part1, int part2, int part3)
    {
        return Math.Max(part1, Math.Max(part2, part3)) - Math.Min(part1, Math.Min(part2, part3));
    }
}
