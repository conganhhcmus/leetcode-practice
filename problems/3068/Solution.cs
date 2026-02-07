public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        int n = nums.Length;
        long[] diff = new long[n];
        int[] indices = new int[n];
        for (int i = 0; i < n; i++)
        {
            indices[i] = i;
            diff[i] = nums[i] - (nums[i] ^ k);
        }
        Array.Sort(diff, indices);
        bool[] pick = new bool[n];
        long ret = 0;
        for (int i = 0; i + 1 < n; i += 2)
        {
            if (diff[i] + diff[i + 1] >= 0) break;
            pick[indices[i]] = true;
            pick[indices[i + 1]] = true;
            ret += nums[indices[i]] ^ k;
            ret += nums[indices[i + 1]] ^ k;
        }
        for (int i = 0; i < n; i++)
        {
            if (!pick[i]) ret += nums[i];
        }
        return ret;
    }
}