#if DEBUG
namespace Problems_373_2;
#endif

public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        IList<IList<int>> ret = [];
        PriorityQueue<(int, int), int> pq = new();
        pq.Enqueue((0, 0), nums1[0] + nums2[0]);
        while (k-- > 0)
        {
            var (i, j) = pq.Dequeue();
            ret.Add([nums1[i], nums2[j]]);
            if (i + 1 < nums1.Length && i + 1 > j)
            {
                pq.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
            }
            if (j + 1 < nums2.Length && j + 1 >= i)
            {
                pq.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
            }

            // (0,0) => (0,1) , (1,0)
            // (0,1) => (1,1) , (0,2)
            // (1,0) => (1,1) , (1,2)
            // duplicate when i + 1 == j or j + 1 == i
            // so accept only one equal sign
        }

        return ret;
    }
}