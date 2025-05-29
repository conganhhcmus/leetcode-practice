namespace Library;

public class Graph
{
    Dictionary<int, List<(int v, int w)>> graph;
    int[] dist; // distance
    int v; // vertices
    public Graph(int v)
    {
        this.v = v;
        graph = [];
        dist = new int[v];
        for (int i = 0; i < v; i++)
        {
            dist[i] = int.MaxValue;
            graph[i] = [];
        }
    }

    public void AddEdge(int u, int v, int w)
    {
        graph[u].Add((v, w));
    }

    // dijkstra with priority queue
    public int[] Dijkstra(int src)
    {
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(src, 0);
        dist[src] = 0;
        while (pq.Count > 0)
        {
            int u = pq.Dequeue();
            foreach (var neighbor in graph.GetValueOrDefault(u, []))
            {
                int v = neighbor.v;
                int w = neighbor.w;
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }
        return dist;
    }

    // prim's algorithm with priority queue
    // The weight of a spanning tree is determined by the minimum sum of weight of all the edge involved in it.
    public int SpanningTree()
    {
        int res = 0;
        PriorityQueue<(int, int), int> pq = new();
        bool[] visited = new bool[v];
        pq.Enqueue((0, 0), 0);
        while (pq.Count > 0)
        {
            var (u, w) = pq.Dequeue();
            if (visited[u]) continue;
            visited[u] = true;
            res += w;
            foreach (var next in graph[u])
            {
                if (!visited[next.v]) pq.Enqueue((next.v, next.w), next.w);
            }
        }

        return res;
    }
}