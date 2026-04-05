public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int n = nums.Length;
        if (k == 0) return 0;
        if (k > n / 2) return -1;
        int[] L = new int[n];
        int[] R = new int[n];
        int[] cost = new int[n];

        PriorityQueue<int, int> pq = new(n);
        bool[] valid = new bool[n];
        Array.Fill(valid, true);
        for (int i = 0; i < n; i++)
        {
            int prev = (i - 1 + n) % n;
            int next = (i + 1) % n;
            L[i] = prev;
            R[i] = next;
            cost[i] = Math.Max(0, Math.Max(nums[prev], nums[next]) + 1 - nums[i]);
            pq.Enqueue(i, cost[i]);
        }
        int ans = 0;
        for (int s = 1; s <= k; s++)
        {
            int i = -1;
            int c = 0;
            while (pq.TryDequeue(out i, out c))
            {
                if (valid[i] && cost[i] == c) break;
            }
            if (i == -1) return -1;
            ans += cost[i];
            int left = L[i];
            int right = R[i];
            // A - left - I - right - B
            valid[left] = false;
            valid[right] = false;
            cost[i] = cost[left] + cost[right] - cost[i];
            L[i] = L[left];
            R[i] = R[right];
            R[L[i]] = i;
            L[R[i]] = i;
            pq.Enqueue(i, cost[i]);
        }
        return ans;
    }
}