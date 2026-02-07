public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        int m = languages.Length;
        HashSet<int>[] map = new HashSet<int>[m + 1];
        for (int i = 0; i < m; i++)
        {
            map[i + 1] = [.. languages[i]];
        }

        bool[,] connected = new bool[m + 1, m + 1];
        for (int i = 0; i <= m; i++)
        {
            connected[i, i] = true;
        }
        for (int i = 0; i < friendships.Length; i++)
        {
            int u = friendships[i][0], v = friendships[i][1];
            for (int j = 1; j <= n; j++)
            {
                if (map[u].Contains(j) && map[v].Contains(j))
                {
                    connected[u, v] = true;
                    connected[v, u] = true;
                    break;
                }
            }
        }

        int ans = int.MaxValue;
        for (int i = 1; i <= n; i++)
        {
            int need = 0;
            HashSet<int>[] extend = new HashSet<int>[m + 1];
            for (int j = 0; j <= m; j++)
            {
                extend[j] = [];
            }
            for (int j = 0; j < friendships.Length; j++)
            {
                int u = friendships[j][0], v = friendships[j][1];
                if (connected[u, v]) continue;
                if (!map[u].Contains(i) && extend[u].Add(i)) need++;
                if (!map[v].Contains(i) && extend[v].Add(i)) need++;
            }
            ans = Math.Min(ans, need);
        }

        return ans;
    }
}