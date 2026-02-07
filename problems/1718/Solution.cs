public class Solution
{
    public int[] ConstructDistancedSequence(int n)
    {
        int[] ans = new int[2 * n - 1];
        bool[] visited = new bool[n + 1];
        Backtracking(ans, n, 0, visited);
        return ans;
    }

    private bool Backtracking(int[] ans, int n, int idx, bool[] visited)
    {
        int len = ans.Length;
        while (idx < len && ans[idx] != 0) idx++; // find nearest slot
        if (idx == len) return true;

        for (int i = n; i >= 1; i--)
        {
            if (visited[i]) continue;
            if (i == 1 && ans[idx] == 0)
            {
                visited[i] = true;
                ans[idx] = i;
                if (Backtracking(ans, n, idx + 1, visited)) return true;
                visited[i] = false;
                ans[idx] = 0;
            }
            else if (ans[idx] == 0 && idx + i < len && ans[idx + i] == 0)
            {
                visited[i] = true;
                ans[idx] = i;
                ans[idx + i] = i;
                if (Backtracking(ans, n, idx + 1, visited)) return true;
                visited[i] = false;
                ans[idx] = 0;
                ans[idx + i] = 0;
            }
        }

        return false;
    }
}