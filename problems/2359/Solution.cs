#if DEBUG
namespace Problems_2359;
#endif

public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;
        bool[] visited = new bool[n];
        int[] map1 = new int[n];
        int[] map2 = new int[n];
        Array.Fill(map1, -1);
        Array.Fill(map2, -1);
        DFS(node1, 0, edges, visited, map1);
        Array.Clear(visited);
        DFS(node2, 0, edges, visited, map2);
        int ret = -1;
        int minLen = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (map1[i] != -1 && map2[i] != -1)
            {
                int max = Math.Max(map1[i], map2[i]);
                if (minLen > max)
                {
                    ret = i;
                    minLen = max;
                }
            }
        }
        return ret;
    }

    void DFS(int curr, int depth, int[] edges, bool[] visited, int[] map)
    {
        if (curr == -1 || visited[curr]) return;
        map[curr] = depth;
        visited[curr] = true;
        DFS(edges[curr], depth + 1, edges, visited, map);
    }
}