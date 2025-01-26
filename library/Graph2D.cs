namespace Library;

public class Pair : IComparable<Pair>, IEquatable<Pair>
{
    public Pair(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Pair()
    {
        X = 0;
        Y = 0;
    }
    public int X;
    public int Y;

    public int CompareTo(Pair pair)
    {
        return $"{X}_{Y}".CompareTo($"{pair.X}_{pair.Y}");
    }

    public bool Equals(Pair other)
    {
        return CompareTo(other) == 0;
    }

    public override int GetHashCode()
    {
        return $"{X}_{Y}".GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Pair);
    }
}
public class Graph2D
{
    Dictionary<Pair, List<(Pair, int)>> _graph;
    int[][] _dist; // distance
    int _n;
    int _m;
    public Graph2D(int n, int m)
    {
        _n = n;
        _m = m;
        _graph = [];
        _dist = new int[_n][];
        for (int i = 0; i < _n; i++)
        {
            _dist[i] = new int[_m];
            for (int j = 0; j < _m; j++)
            {
                _dist[i][j] = int.MaxValue;
                _graph[new Pair(i, j)] = [];
            }
        }
    }

    public void AddEdge(Pair u, Pair v, int weight)
    {
        _graph[u].Add((v, weight));
    }

    // dijkstra with priority queue
    public void Dijkstra(Pair src)
    {
        PriorityQueue<Pair, int> pq = new(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        pq.Enqueue(src, 0);
        _dist[src.X][src.Y] = 0;
        while (pq.Count > 0)
        {
            Pair u = pq.Dequeue();
            foreach (var neighbor in _graph.GetValueOrDefault(u, []))
            {
                Pair v = neighbor.Item1;
                int weight = neighbor.Item2;
                if (_dist[u.X][u.Y] + weight < _dist[v.X][v.Y])
                {
                    _dist[v.X][v.Y] = _dist[u.X][u.Y] + weight;
                    pq.Enqueue(v, _dist[v.X][v.Y]);
                }
            }
        }
    }

    // prim's algorithm with priority queue
    public int SpanningTree()
    {
        int res = 0;
        PriorityQueue<(Pair, int), int> pq = new(Comparer<int>.Create((a, b) => a - b));
        HashSet<Pair> visited = [];
        pq.Enqueue((new Pair(0, 0), 0), 0);
        while (pq.Count > 0)
        {
            var (u, w) = pq.Dequeue();
            if (visited.Contains(u)) continue;
            visited.Add(u);
            res += w;
            foreach (var neighbor in _graph[u])
            {
                Pair v = neighbor.Item1;
                int weight = neighbor.Item2;
                if (!visited.Contains(v)) pq.Enqueue((v, weight), weight);
            }
        }

        return res;
    }

    public int GetDistance(Pair target)
    {
        return _dist[target.X][target.Y];
    }
}