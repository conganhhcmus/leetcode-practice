public class Solution
{
    public int[] CountTasks(int[] tasks, int[] shifts)
    {
        int n = tasks.Length, m = shifts.Length;
        long[] prefix = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + tasks[i];
        }
        int[] ans = new int[m];
        long remain = 0;
        for (int i = 0; i < m; i++)
        {
            int left = 0, right = n, best = 0;
            long total = remain + shifts[i];
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (prefix[mid] <= total)
                {
                    best = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (best == n) remain = 0;
            else remain = total;
            ans[i] = n - best;
        }
        return ans;
    }
}
