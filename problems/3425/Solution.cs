#if DEBUG
namespace Problems_3425;
#endif

public class Solution
{
    int[] ret = [0, int.MaxValue];
    Stack<int> st = [];
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
        st.Push(0);
        DFS(0, -1, graph, nums, [], 1, [0]);

        return ret;
    }

    void DFS(int curr, int parent, List<int[]>[] graph, int[] nums, Dictionary<int, int> prev, int len, List<int> prefixSum)
    {
        int val = nums[curr];
        int saved = prev.GetValueOrDefault(val, 0);
        prev[val] = len;
        foreach (int[] neighbor in graph[curr])
        {
            int next = neighbor[0], weight = neighbor[1];
            if (next == parent) continue;
            prefixSum.Add(prefixSum[^1] + weight);
            int dupIdx = Math.Max(st.Peek(), prev.GetValueOrDefault(nums[next], 0));
            st.Push(dupIdx);
            int sumWithoutDup = prefixSum[len] - prefixSum[dupIdx];
            if (ret[0] < sumWithoutDup)
            {
                ret[0] = sumWithoutDup;
                ret[1] = len - dupIdx + 1;
            }
            if (ret[0] == sumWithoutDup)
            {
                ret[1] = Math.Min(ret[1], len - dupIdx + 1);
            }
            DFS(next, curr, graph, nums, prev, len + 1, prefixSum);
            prefixSum.RemoveAt(prefixSum.Count - 1);
            st.Pop();
        }
        prev[val] = saved;
    }
}