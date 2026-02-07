public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int m = queries.Length;
        int low = 0, high = m, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(nums, queries, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }
        return ans;
    }

    bool Ok(int[] nums, int[][] queries, int mid)
    {
        int n = nums.Length;
        int[] diff = new int[n + 1];
        for (int i = 0; i < mid; i++)
        {
            diff[queries[i][0]] += queries[i][2];
            diff[queries[i][1] + 1] -= queries[i][2];
        }

        int curr = 0;
        for (int i = 0; i < n; i++)
        {
            curr += diff[i];
            if (curr < nums[i]) return false;
        }
        return true;
    }
}