namespace Problem_3372;
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[][] edges1 = [[0, 1]];
        int[][] edges2 = [[0, 1]];
        int k = 0;
        Console.WriteLine($"[{string.Join(", ", solution.MaxTargetNodes(edges1, edges2, k))}]");
    }
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        int[] result = new int[edges1.Length + 1];
        Dictionary<int, List<int>> graph1 = BuildGraph(edges1);
        Dictionary<int, List<int>> graph2 = BuildGraph(edges2);

        int maxNeighbors = 0;
        foreach (var node in graph2.Keys)
        {
            maxNeighbors = Math.Max(maxNeighbors, BFS(graph2, node, k - 1));
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = BFS(graph1, i, k) + maxNeighbors;
        }

        return result;
    }

    private int BFS(Dictionary<int, List<int>> graph, int start, int maxH)
    {
        if (maxH < 0) return 0;
        if (maxH == 0) return 1;
        Queue<(int, int)> queue = [];
        HashSet<int> visited = [];

        if (visited.Add(start))
        {
            queue.Enqueue((start, 0));
        }

        int count = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                var (node, h) = queue.Dequeue();
                if (h > maxH) continue;
                count++;

                foreach (var neighbor in graph[node])
                {
                    if (visited.Add(neighbor))
                    {
                        queue.Enqueue((neighbor, h + 1));
                    }
                }
            }
        }

        return count;
    }

    private Dictionary<int, List<int>> BuildGraph(int[][] edges)
    {
        Dictionary<int, List<int>> graph = [];
        foreach (int[] edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }
            graph[edge[0]].Add(edge[1]);

            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }
            graph[edge[1]].Add(edge[0]);
        }

        return graph;
    }
}