public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        IList<IList<int>> ret = [];
        PriorityQueue<int[], int> pq = new();
        for (int i = 0; i < nums1.Length; i++) pq.Enqueue([i, 0], nums1[i] + nums2[0]);
        while (k > 0 && pq.Count > 0)
        {
            int[] minPair = pq.Dequeue();
            ret.Add([nums1[minPair[0]], nums2[minPair[1]]]);
            k--;
            if (minPair[1] + 1 < nums2.Length)
            {
                pq.Enqueue([minPair[0], minPair[1] + 1], nums1[minPair[0]] + nums2[minPair[1] + 1]);
            }
        }

        return ret;
    }
}