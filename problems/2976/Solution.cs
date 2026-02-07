public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        List<int[]>[] graph = new List<int[]>[26];
        for (int i = 0; i < 26; i++)
        {
            graph[i] = [];
        }
        for (int i = 0; i < cost.Length; i++)
        {
            int u = original[i] - 'a', v = changed[i] - 'a', c = cost[i];
            graph[u].Add([v, c]);
        }

        long[,] map = new long[26, 26];
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                map[i, j] = long.MaxValue;
            }
            map[i, i] = 0;
        }

        // pre calc cost
        for (int i = 0; i < 26; i++)
        {
            PriorityQueue<int, long> pq = new();
            pq.Enqueue(i, 0);
            while (pq.Count > 0)
            {
                int u = pq.Dequeue();
                foreach (var next in graph[u])
                {
                    int v = next[0], c = next[1];
                    long nC = map[i, u] + c;
                    if (nC < map[i, v])
                    {
                        map[i, v] = nC;
                        pq.Enqueue(v, nC);
                    }
                }
            }
        }

        long ans = 0;
        for (int i = 0; i < source.Length; i++)
        {
            if (map[source[i] - 'a', target[i] - 'a'] == long.MaxValue) return -1;
            ans += map[source[i] - 'a', target[i] - 'a'];
        }
        return ans;
    }
}