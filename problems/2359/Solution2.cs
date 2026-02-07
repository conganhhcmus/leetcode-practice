public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;
        int[] map1 = BFS(node1, edges);
        int[] map2 = BFS(node2, edges);
        int ret = -1;
        int minLen = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (map1[i] == -1 || map2[i] == -1) continue;
            int max = Math.Max(map1[i], map2[i]);
            if (minLen > max)
            {
                ret = i;
                minLen = max;
            }
        }
        return ret;
    }

    int[] BFS(int node, int[] edges)
    {
        int n = edges.Length;
        int[] map = new int[n];
        Array.Fill(map, -1);
        Queue<int> queue = [];
        queue.Enqueue(node);
        int len = 0;
        map[node] = len;
        while (queue.Count > 0)
        {
            for (int i = queue.Count; i > 0; i--)
            {
                int curr = queue.Dequeue();
                map[curr] = len;
                int next = edges[curr];
                if (next != -1 && map[next] == -1)
                {
                    queue.Enqueue(next);
                }
            }
            len++;
        }
        return map;
    }
}