namespace Problem_3373;
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[][] edges1 = [[0, 1], [0, 2], [2, 3], [2, 4]];
        int[][] edges2 = [[0, 1], [0, 2], [0, 3], [2, 7], [1, 4], [4, 5], [4, 6]];
        Console.WriteLine($"[{string.Join(",", solution.MaxTargetNodes(edges1, edges2))}]");
    }
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        int[] result = new int[edges1.Length + 1];
        Dictionary<int, List<int>> graph1 = BuildGraph(edges1);

        Dictionary<int, List<int>> graph2 = BuildGraph(edges2);

        int[] depth1 = ComputeDepth(graph1);
        int sizeE1 = 0, sizeO1 = 0;
        foreach (int depth in depth1)
        {
            if (depth % 2 == 0)
            {
                sizeE1++;
            }
            else
            {
                sizeO1++;
            }
        }
        int[] depth2 = ComputeDepth(graph2);
        int sizeE2 = 0, sizeO2 = 0;
        foreach (int depth in depth2)
        {
            if (depth % 2 == 0)
            {
                sizeE2++;
            }
            else
            {
                sizeO2++;
            }
        }
        int maxNeighbor2 = Math.Max(sizeE2, sizeO2);

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (depth1[i] % 2 == 0 ? sizeE1 : sizeO1) + maxNeighbor2;
        }

        return result;
    }

    private int[] ComputeDepth(Dictionary<int, List<int>> graph)
    {
        int n = graph.Keys.Count;
        int[] depth = new int[n];
        Queue<int> queue = [];
        queue.Enqueue(0);
        Array.Fill(depth, -1);
        depth[0] = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var neighbor in graph[node])
            {
                if (depth[neighbor] == -1)
                {
                    depth[neighbor] = 1 - depth[node];
                    queue.Enqueue(neighbor);
                }
            }
        }

        return depth;
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