#if DEBUG
namespace Problems_2389_2;
#endif

public class Solution
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        int n = nums.Length;
        int m = queries.Length;
        Array.Sort(nums);
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        int[] ret = new int[m];
        for (int i = 0; i < m; i++)
        {
            ret[i] = BinarySearch(prefixSum, queries[i]);
        }
        return ret;
    }

    int BinarySearch(long[] prefixSum, int target)
    {
        int low = 0, high = prefixSum.Length - 1, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (prefixSum[mid] <= target)
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }
}