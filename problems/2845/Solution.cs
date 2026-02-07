public class Solution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
    {
        int n = nums.Count;
        int[] count = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            count[i + 1] = count[i] + (nums[i] % modulo == k ? 1 : 0);
        }
        long ret = 0;
        // each i count j where j < i  and (count[i] - count[j]) % modulo == k
        // count[j] % modulo == count[i] % modulo - k
        // count[j] % modulo == (count[i] - k) % modulo
        // count[j] % modulo == (count[i] - k + modulo) % modulo // remove negative modulo
        Dictionary<int, int> map = [];
        for (int i = 0; i <= n; ++i)
        {
            ret += map.GetValueOrDefault((count[i] + modulo - k) % modulo, 0);
            map[count[i] % modulo] = map.GetValueOrDefault(count[i] % modulo, 0) + 1;
        }

        return ret;
    }
}