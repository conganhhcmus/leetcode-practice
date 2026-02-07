public class Solution
{
    public long[] FindMaxSum(int[] nums1, int[] nums2, int k)
    {
        int n = nums1.Length;
        int[][] ns = new int[n][];
        for (int i = 0; i < n; i++)
        {
            ns[i] = [nums1[i], i];
        }

        Array.Sort(ns, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });

        long[] ans = new long[n];
        PriorityQueue<int, int> pq = new();
        long sum = 0;
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            while (j < i && ns[j][0] < ns[i][0])
            {
                sum += nums2[ns[j][1]];
                pq.Enqueue(nums2[ns[j][1]], nums2[ns[j][1]]);
                while (pq.Count > k) sum -= pq.Dequeue();
                j++;
            }

            ans[ns[i][1]] = sum;
        }

        return ans;
    }
}