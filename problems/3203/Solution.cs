#if DEBUG
namespace Problems_3203;
#endif

public class Solution
{
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        int n1 = edges1.Length + 1, n2 = edges2.Length + 1;
        var graph1 = BuildUndirectedGraph(edges1);
        var graph2 = BuildUndirectedGraph(edges2);

        int diameter1 = FindDiameter(graph1, n1);
        int diameter2 = FindDiameter(graph2, n2);
        int combinedDiameter = (diameter1 + 1) / 2 + (diameter2 + 1) / 2 + 1;
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private Dictionary<T, List<T>> BuildUndirectedGraph<T>(T[][] edges)
    {
        Dictionary<T, List<T>> graph = [];
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }
            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        return graph;
    }

    private int[] FindFarthestNode(Dictionary<int, List<int>> graph, int source, int n)
    {
        bool[] visited = new bool[n];
        visited[source] = true;
        Queue<int> queue = [];
        queue.Enqueue(source);
        int maximumDistance = 0, farthestNode = source;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                int current = queue.Dequeue();
                farthestNode = current;
                foreach (int neighbor in graph.GetValueOrDefault(current, []))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            if (queue.Count > 0) maximumDistance++;
        }

        return [farthestNode, maximumDistance];
    }

    private int FindDiameter(Dictionary<int, List<int>> graph, int n)
    {
        int[] farthestNodes = FindFarthestNode(graph, 0, n);
        int[] farthestNodes2 = FindFarthestNode(graph, farthestNodes[0], n);
        return farthestNodes2[1];
    }
}