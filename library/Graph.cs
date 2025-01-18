namespace Library;

public class Graph
{
    Dictionary<int, List<(int, int)>> _graph;
    int[] _dist; // distance
    int _v; // vertices
    public Graph(int v)
    {
        _v = v;
        _graph = [];
        _dist = new int[_v];
        for (int i = 0; i < _v; i++)
        {
            _dist[i] = int.MaxValue;
            _graph[i] = [];
        }
    }

    public void AddEdge(int u, int v, int weight)
    {
        _graph[u].Add((v, weight));
    }

    // dijkstra with priority queue
    public void Dijkstra(int src)
    {
        PriorityQueue<int, int> pq = new(Comparer<int>.Create((a, b) => a - b));
        pq.Enqueue(src, 0);
        _dist[src] = 0;
        while (pq.Count > 0)
        {
            int u = pq.Dequeue();
            foreach (var neighbor in _graph.GetValueOrDefault(u, []))
            {
                int v = neighbor.Item1;
                int weight = neighbor.Item2;
                if (_dist[u] + weight < _dist[v])
                {
                    _dist[v] = _dist[u] + weight;
                    pq.Enqueue(v, _dist[v]);
                }
            }
        }
    }

    public int GetDistance(int target)
    {
        return _dist[target];
    }
}