public class Solution
{
    public int MinSessions(int[] tasks, int sessionTime)
    {
        int n = tasks.Length;
        int low = 1, high = n, ans = n;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(new int[mid], tasks, sessionTime, 0))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;
    }

    bool Ok(int[] sessions, int[] tasks, int sessionTime, int idx)
    {
        if (idx == tasks.Length) return true;
        int currTask = tasks[idx];
        for (int i = 0; i < sessions.Length; i++)
        {
            if (i > 0 && sessions[i] == sessions[i - 1]) continue; // make sessions is sort non-increasing
            if (sessions[i] + currTask > sessionTime) continue;
            sessions[i] += currTask;
            if (Ok(sessions, tasks, sessionTime, idx + 1)) return true;
            sessions[i] -= currTask;
        }

        return false;
    }
}