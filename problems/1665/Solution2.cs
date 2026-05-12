public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        int n = tasks.Length;
        Array.Sort(tasks, (a, b) => (b[1] - b[0]).CompareTo(a[1] - a[0]));
        int ans = 0;
        int remain = 0;
        // completed from 0 to n-1 tasks
        for (int i = 0; i < n; i++)
        {
            if (remain < tasks[i][1])
            {
                ans += tasks[i][1] - remain;
            }
            remain = Math.Max(tasks[i][1] - tasks[i][0], remain - tasks[i][0]);
        }

        return ans;
    }
}
