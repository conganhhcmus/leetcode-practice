#if DEBUG
namespace Problems_2389;
#endif

public class Solution
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int m = queries.Length;
        int[] idx = new int[m];
        for (int i = 0; i < m; i++)
        {
            idx[i] = i;
        }
        Array.Sort(queries, idx);
        int[] ret = new int[m];
        long sum = 0;
        int j = 0;
        for (int i = 0; i < m; i++)
        {
            while (j < n && sum + nums[j] <= queries[i])
            {
                sum += nums[j];
                j++;
            }
            ret[idx[i]] = j;
        }
        return ret;
    }
}