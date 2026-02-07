public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        int[] inDegree = new int[n];
        for (int i = 0; i < n; i++)
        {
            inDegree[favorite[i]]++;
        }
        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        int[] depths = new int[n];
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            int v = favorite[u];
            depths[v] = Math.Max(depths[v], depths[u] + 1);
            if (--inDegree[v] == 0)
            {
                queue.Enqueue(v);
            }
        }

        int longestCycle = 0;
        int twoCycle = 0;
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0) continue;
            int curr = i;
            int len = 0;
            while (inDegree[curr] != 0)
            {
                inDegree[curr] = 0;
                curr = favorite[curr];
                len++;
            }

            if (len == 2)
            {
                twoCycle += 2 + depths[curr] + depths[favorite[curr]];
            }

            longestCycle = Math.Max(longestCycle, len);
        }

        return Math.Max(longestCycle, twoCycle);
    }
}