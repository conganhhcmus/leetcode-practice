public class Solution
{
    public IList<IList<int>> Supersequences(string[] words)
    {
        int n = words.Length;
        Dictionary<int, List<int>> graph = [];
        HashSet<int> twice = [];
        HashSet<int> nodes = [];
        foreach (string word in words)
        {
            int u = word[0] - 'a';
            int v = word[1] - 'a';
            if (u == v)
            {
                twice.Add(u);
                continue;
            }
            nodes.Add(u);
            nodes.Add(v);
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            graph[u].Add(v);
        }

        // binary ans
        List<HashSet<int>> combinations = [];
        int left = 0, right = nodes.Count;
        while (left <= right)
        {
            List<HashSet<int>> temp = [];
            int mid = left + (right - left) / 2;
            foreach (HashSet<int> comb in Combinations(nodes, mid))
            {
                if (!ContainCycle(graph, [.. twice, .. comb]))
                {
                    temp.Add(comb);
                }
            }
            if (temp.Count > 0) // accept ans
            {
                combinations = temp;
                right = mid - 1;
            }
            else left = mid + 1;
        }

        IList<IList<int>> ans = [];
        for (int i = 0; i < combinations.Count; i++)
        {
            ans.Add(BuildResult([.. combinations[i], .. twice], nodes));
        }

        return ans;
    }

    private List<HashSet<int>> Combinations(HashSet<int> nodes, int length)
    {
        int n = nodes.Count;
        List<HashSet<int>> ans = [];
        HashSet<int> tmp = [];
        CombinationsUtil(0, length);
        return ans;

        void CombinationsUtil(int start, int len)
        {
            if (len == 0)
            {
                ans.Add([.. tmp]);
                return;
            }
            for (int i = start; i < n; i++)
            {
                tmp.Add(nodes.ElementAt(i));

                CombinationsUtil(i + 1, len - 1);

                tmp.Remove(nodes.ElementAt(i));
            }
        }
    }

    private List<int> BuildResult(HashSet<int> twice, HashSet<int> nodes)
    {
        List<int> ans = [];
        for (int i = 0; i < 26; i++)
        {
            if (twice.Contains(i)) ans.Add(2);
            else if (nodes.Contains(i)) ans.Add(1);
            else ans.Add(0);
        }

        return ans;
    }

    // using Topological sort
    private bool ContainCycle(Dictionary<int, List<int>> graph, HashSet<int> twice)
    {
        Dictionary<int, int> inDegree = [];
        foreach (var pair in graph)
        {
            if (twice.Contains(pair.Key)) continue;
            foreach (var v in pair.Value)
            {
                if (twice.Contains(v)) continue;
                inDegree[pair.Key] = inDegree.GetValueOrDefault(pair.Key, 0);
                inDegree[v] = inDegree.GetValueOrDefault(v, 0) + 1;
            }
        }

        Queue<int> queue = [];
        foreach (var pair in inDegree)
        {
            if (pair.Value == 0) queue.Enqueue(pair.Key);
        }

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var neighbor in graph.GetValueOrDefault(node, []))
            {
                if (twice.Contains(neighbor)) continue;
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        // check has a cycle
        foreach (int val in inDegree.Values)
        {
            if (val != 0) return true;
        }

        return false;
    }
}