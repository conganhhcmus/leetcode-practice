public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = [];
        int[] inDegree = new int[n];
        foreach (int[] inv in invocations)
        {
            int u = inv[0], v = inv[1];
            g[u].Add(v);
            inDegree[v]++;
        }
        Queue<int> q = [];
        q.Enqueue(k);
        bool[] suspicious = new bool[n];
        suspicious[k] = true;
        while (q.Count > 0)
        {
            int u = q.Dequeue();
            foreach (int v in g[u])
            {
                inDegree[v]--;
                if (!suspicious[v])
                {
                    suspicious[v] = true;
                    q.Enqueue(v);
                }
            }
        }
        bool canRemoveAll = true;
        List<int> ans = [];
        for (int i = 0; i < n; i++)
        {
            if (suspicious[i] && inDegree[i] > 0)
            {
                canRemoveAll = false;
                break;
            }
            else if (!suspicious[i])
            {
                ans.Add(i);
            }
        }

        if (!canRemoveAll)
        {
            List<int> allNodes = [];
            for (int i = 0; i < n; i++)
            {
                allNodes.Add(i);
            }
            return allNodes;
        }
        return ans;
    }
}
