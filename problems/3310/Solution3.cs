public class Solution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        int[] head = new int[n];
        for (int i = 0; i < n; i++) head[i] = -1;
        int m = invocations.Length;
        int[] to = new int[m];
        int[] next = new int[m];
        for (int i = 0; i < m; i++)
        {
            int u = invocations[i][0];
            int v = invocations[i][1];
            to[i] = v;
            next[i] = head[u];
            head[u] = i;
        }
        bool[] suspicious = new bool[n];
        int[] q = new int[n];
        int headQ = 0, tailQ = 0;
        q[tailQ++] = k;
        suspicious[k] = true;
        while (headQ < tailQ)
        {
            int u = q[headQ++];
            for (int e = head[u]; e != -1; e = next[e])
            {
                int v = to[e];
                if (!suspicious[v])
                {
                    suspicious[v] = true;
                    q[tailQ++] = v;
                }
            }
        }

        bool canRemove = true;
        for (int i = 0; i < m; i++)
        {
            int u = invocations[i][0];
            int v = invocations[i][1];
            if (!suspicious[u] && suspicious[v])
            {
                canRemove = false;
                break;
            }
        }
        if (canRemove)
        {
            List<int> ans = [];
            for (int i = 0; i < n; i++)
            {
                if (!suspicious[i]) ans.Add(i);
            }
            return ans;
        }
        else
        {
            List<int> ans = [];
            for (int i = 0; i < n; i++) ans.Add(i);
            return ans;
        }
    }
}
