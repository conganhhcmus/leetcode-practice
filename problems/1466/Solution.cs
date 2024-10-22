namespace Problem_1466;

public class Solution
{
    public static void Execute()
    {
        int n = 6;
        int[][] connections = [[1, 0], [1, 2], [3, 2], [3, 4]];
        var solution = new Solution();
        Console.WriteLine(solution.MinReorder(n, connections));  // Output: 3
    }
    public int MinReorder(int n, int[][] connections)
    {
        int count = 0;
        bool[] mapped = new bool[n];
        Dictionary<int, List<(int city, bool direction)>> graph = [];

        foreach (var connection in connections)
        {
            graph[connection[0]] = graph.GetValueOrDefault(connection[0], []);
            graph[connection[0]].Add((connection[1], true));

            graph[connection[1]] = graph.GetValueOrDefault(connection[1], []);
            graph[connection[1]].Add((connection[0], false));
        }

        void DFS(int city)
        {
            mapped[city] = true;

            foreach (var (node, direction) in graph[city])
            {
                if (mapped[node]) continue;
                if (direction) count++;

                DFS(node);
            }
        }

        DFS(0);
        return count;
    }
}