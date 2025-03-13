#if DEBUG
namespace Problems_3356_3;
#endif

public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length, k = 0, curr = 0;
        int[] diff = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            while (curr + diff[i] < nums[i])
            {
                k++;
                if (k > queries.Length) return -1;
                int l = queries[k - 1][0], r = queries[k - 1][1], val = queries[k - 1][2];
                if (r >= i)
                {
                    diff[Math.Max(l, i)] += val;
                    diff[r + 1] -= val;
                }
            }
            curr += diff[i];
        }
        return k;
    }
}