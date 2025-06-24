#if DEBUG
namespace Problems_2200;
#endif

public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        int n = nums.Length;
        List<int> ret = [];
        List<int> indices = [];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == key) indices.Add(i);
        }
        int p1 = 0, p2 = 0;
        while (p1 < n && p2 < indices.Count)
        {
            if (Math.Abs(p1 - indices[p2]) <= k)
            {
                ret.Add(p1);
            }
            else
            {
                if (p1 > indices[p2])
                {
                    p2++;
                    continue;
                }
            }
            p1++;
        }
        return ret;
    }
}