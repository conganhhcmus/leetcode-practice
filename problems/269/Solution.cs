public class Solution
{
    public string foreignDictionary(string[] words)
    {
        List<int>[] adj = new List<int>[26];
        for (int i = 0; i < 26; i++)
        {
            adj[i] = [];
        }
        int n = words.Length;
        if (n == 1) return words[0];
        Dictionary<int, int> inDegree = [];
        for (int i = 0; i < n; i++)
        {
            foreach (char ch in words[i])
            {
                inDegree.TryAdd(ch - 'a', 0);
            }
        }
        for (int i = 1; i < n; i++)
        {
            string a = words[i - 1];
            string b = words[i];
            bool foundDiff = false;
            for (int j = 0; j < Math.Min(a.Length, b.Length); j++)
            {
                if (a[j] != b[j])
                {
                    adj[a[j] - 'a'].Add(b[j] - 'a');
                    inDegree[b[j] - 'a']++;
                    foundDiff = true;
                    break;
                }
            }
            if (!foundDiff && a.Length > b.Length) return "";
        }

        // Topological sort
        Queue<int> queue = [];
        foreach (var pair in inDegree)
        {
            if (pair.Value == 0) queue.Enqueue(pair.Key);
        }
        StringBuilder ans = new();

        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            char ch = (char)('a' + curr);
            ans.Append(ch);
            foreach (int neighbor in adj[curr])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        foreach (var pair in inDegree)
        {
            // has cycle
            if (pair.Value != 0) return "";
        }
        return ans.ToString();
    }
}
