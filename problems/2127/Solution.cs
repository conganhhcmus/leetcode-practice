#if DEBUG
namespace Problems_2127;
#endif

public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        // sum of all chains of persons
        // or just largest cycle of persons
        int n = favorite.Length;
        Dictionary<int, List<int>> graph = [];
        for (int i = 0; i < n; i++)
        {
            if (!graph.ContainsKey(favorite[i]))
            {
                graph[favorite[i]] = [];
            }
            graph[favorite[i]].Add(i);
        }
        // longest cycle
        int longestCycle = 0;
        int twoCycle = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                Dictionary<int, int> map = [];
                int curr = i;
                int distance = 0;
                while (true)
                {
                    if (visited[curr]) break;
                    visited[curr] = true;
                    map[curr] = distance++;
                    int next = favorite[curr];
                    if (map.ContainsKey(next))
                    {
                        int cycleLen = distance - map[next];
                        longestCycle = Math.Max(longestCycle, cycleLen);
                        if (cycleLen == 2)
                        {
                            bool[] newVisited = new bool[n];
                            newVisited[curr] = true;
                            newVisited[next] = true;
                            twoCycle += 2 + BFS(curr, newVisited, graph) + BFS(next, newVisited, graph);
                        }
                        break;
                    }
                    curr = next;
                }
            }
        }

        return Math.Max(twoCycle, longestCycle);
    }

    private int BFS(int start, bool[] visited, Dictionary<int, List<int>> graph)
    {
        Queue<(int, int)> queue = [];
        queue.Enqueue((start, 0));
        int maxDistance = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                (int node, int distance) = queue.Dequeue();
                maxDistance = Math.Max(maxDistance, distance);
                foreach (int neighbor in graph.GetValueOrDefault(node, []))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue((neighbor, distance + 1));
                    }
                }
            }
        }
        return maxDistance;
    }
}

