public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        Queue<int> q = [];
        bool[] vis = new bool[n];
        q.Enqueue(start);
        vis[start] = true;
        bool IsValid(int x) => x >= 0 && x < n;
        while (q.Count > 0)
        {
            int u = q.Dequeue();
            if (arr[u] == 0) return true;
            int v1 = u - arr[u], v2 = u + arr[u];
            if (IsValid(v1) && !vis[v1])
            {
                vis[v1] = true;
                q.Enqueue(v1);
            }
            if (IsValid(v2) && !vis[v2])
            {
                vis[v2] = true;
                q.Enqueue(v2);
            }
        }
        return false;
    }
}
