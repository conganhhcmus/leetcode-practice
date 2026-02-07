public class Solution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        // n tasks, m workers, pills
        // n = m = pills = 5*10^4
        // sort tasks, sort workers
        int n = tasks.Length, m = workers.Length;
        Array.Sort(tasks);
        Array.Sort(workers);
        int low = 0, high = n, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CanAssigned(tasks, workers, pills, strength, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    bool CanAssigned(int[] tasks, int[] workers, int pills, int strength, int k)
    {
        if (k == 0) return true;
        if (k > tasks.Length || k > workers.Length) return false;

        LinkedList<int> dq = new();
        int n = workers.Length;
        int j = 0;
        for (int i = n - k; i < n; i++)
        {
            while (j < k && tasks[j] <= workers[i] + strength)
            {
                dq.AddLast(tasks[j]);
                j++;
            }
            if (dq.Count == 0) return false;
            if (dq.First.Value <= workers[i])
            {
                dq.RemoveFirst();
            }
            else if (pills > 0)
            {
                pills--;
                dq.RemoveLast();
            }
            else return false;
        }
        return true;
    }
}