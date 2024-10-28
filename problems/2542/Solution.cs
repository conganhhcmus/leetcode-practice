namespace Problem_2542;

public class Solution
{
    public static void Execute()
    {
        int[] nums1 = [2, 1, 14, 12];
        int[] nums2 = [11, 7, 13, 6];
        int k = 3;
        var solution = new Solution();
        Console.WriteLine(solution.MaxScore(nums1, nums2, k));
    }
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        Array.Sort(nums2, nums1);
        PriorityQueue<int, int> queue = new();

        long sum = 0;
        for (int i = 1; i <= k; i++)
        {
            sum += nums1[^i]; ;
            queue.Enqueue(nums1[^i], nums1[^i]);
        }

        long ans = sum * nums2[^k];

        for (int i = k + 1; i <= nums1.Length; i++)
        {
            sum = sum + nums1[^i] - queue.EnqueueDequeue(nums1[^i], nums1[^i]);
            ans = Math.Max(ans, sum * nums2[^i]);
        }

        return ans;
    }
}