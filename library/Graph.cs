namespace Library;

public class Graph
{
    Dictionary<T, List<T>> BuildUndirectedGraph<T>(T[][] edges)
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

    Dictionary<T, List<T>> BuildGraph<T>(T[][] edges)
    {
        Dictionary<T, List<T>> graph = [];
        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }
            graph[edge[0]].Add(edge[1]);
        }
        return graph;
    }
}