public class Solution
{
    public int ShortestPathLength(int[][] graph)
    {
        int n = graph.Length;
        int fullBitMask = (1 << n) - 1;
        Queue<(int, int)> queue = [];
        bool[,] visited = new bool[n, fullBitMask + 1];

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue((i, (1 << i)));
            visited[i, (1 << i)] = true;
        }

        int len = 0;
        while (queue.Count > 0)
        {
            for (int i = queue.Count; i > 0; i--)
            {
                var (curr, bitMask) = queue.Dequeue();
                if (bitMask == fullBitMask)
                {
                    return len;
                }
                foreach (int next in graph[curr])
                {
                    int newBitMask = bitMask | (1 << next);
                    if (visited[next, newBitMask]) continue;
                    visited[next, newBitMask] = true;
                    queue.Enqueue((next, bitMask | (1 << next)));
                }
            }
            len++;
        }
        return len;
    }
}