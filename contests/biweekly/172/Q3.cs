public class Solution
{
    public long MaximumScore(int[] nums, string s)
    {
        int n = nums.Length;
        long ans = 0L;
        PriorityQueue<int, int> pq = new();
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            pq.Enqueue(x, -x);
            if (s[i] == '1')
            {
                ans += pq.Dequeue();
            }
        }
        return ans;
    }
}
