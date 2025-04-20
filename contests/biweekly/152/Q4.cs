#if DEBUG
namespace Biweekly_152_Q4;
#endif

public class Solution
{
    int maxSum = 0;

    int minLen = int.MaxValue;

    int[] trace = new int[50001];

    public int[] LongestSpecialPath(int[][] edges, int[] nums)
    {
        int n = edges.Length + 1;
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }

        Array.Fill(trace, -1);
        DFS(0, -1, graph, nums, [], 0, 0, -1, 0);

        return [maxSum, minLen];
    }

    void DFS(int curr, int parent, List<int[]>[] graph, int[] nums, List<int> path, int left, int right, int twice, int sum)
    {
        int prev = trace[nums[curr]];
        trace[nums[curr]] = right;
        while (left <= Math.Min(prev, twice))
        {
            sum -= path[left];
            left++;
        }
        twice = Math.Max(twice, prev);

        if (maxSum < sum)
        {
            maxSum = sum;
            minLen = right - left + 1;
        }
        else if (maxSum == sum)
        {
            minLen = Math.Min(minLen, right - left + 1);
        }

        foreach (int[] neighbor in graph[curr])
        {
            int next = neighbor[0], weight = neighbor[1];
            if (next == parent) continue;

            path.Add(weight);
            DFS(next, curr, graph, nums, path, left, right + 1, twice, sum + weight);
            path.RemoveAt(path.Count - 1);
        }

        trace[nums[curr]] = prev;
    }
}
