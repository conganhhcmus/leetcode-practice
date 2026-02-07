public class Solution
{
    public long[] ResultArray(int[] nums, int k)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            nums[i] %= k;
        }
        long[] ret = new long[k];
        long[] prev = new long[k];
        for (int i = 0; i < n; i++)
        {
            long[] curr = new long[k];
            curr[nums[i]]++;
            for (int j = 0; j < k; j++)
            {
                int mod = j * nums[i] % k;
                curr[mod] += prev[j];
            }
            for (int j = 0; j < k; j++)
            {
                ret[j] += curr[j];
            }
            Array.Copy(curr, prev, k);
        }
        return ret;
    }
}