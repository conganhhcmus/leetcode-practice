public class Solution
{
    public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
    {
        int n = nums.Length, m = changeIndices.Length;
        long sum = 0;
        for (int i = 0; i < n; i++) sum += nums[i];
        int low = 1, high = m, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(mid))
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

        bool Ok(int t)
        {
            int[] first = new int[n];
            Array.Fill(first, -1);
            for (int i = 0; i < t; i++)
            {
                int idx = changeIndices[i] - 1;
                if (nums[idx] > 0 && first[idx] == -1) first[idx] = i;
            }
            int free = 0;
            long saved = 0;
            PriorityQueue<int, int> pq = new();
            for (int i = t - 1; i >= 0; i--)
            {
                int idx = changeIndices[i] - 1;
                if (i == first[idx])
                {
                    pq.Enqueue(nums[idx], nums[idx]);
                    saved += nums[idx];
                    if (free == 0)
                    {
                        saved -= pq.Dequeue();
                        free++;
                    }
                    else free--;
                }
                else free++;
            }
            int choosen = pq.Count;
            long cost1 = 2L * choosen;
            long cost2 = sum + n - (choosen + saved);
            return cost1 + cost2 <= t;
        }
    }
}
