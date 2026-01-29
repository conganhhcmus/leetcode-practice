#if DEBUG
namespace Problems_2976_2;
#endif

public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        long INF = long.MaxValue / 4;
        long[][] dist = new long[26][];
        for (int i = 0; i < 26; i++)
        {
            dist[i] = new long[26];
        }
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                dist[i][j] = INF;
            }
            dist[i][i] = 0;
        }

        for (int i = 0; i < cost.Length; i++)
        {
            int u = original[i] - 'a', v = changed[i] - 'a', c = cost[i];
            dist[u][v] = Math.Min(dist[u][v], c);
        }
        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
        long ans = 0;

        for (int i = 0; i < source.Length; i++)
        {
            int s = source[i] - 'a', t = target[i] - 'a';
            if (dist[s][t] >= INF) return -1;
            ans += dist[s][t];
        }

        return ans;
    }
}