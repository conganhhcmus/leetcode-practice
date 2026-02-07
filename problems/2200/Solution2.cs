public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        List<int> ret = [];
        int n = nums.Length;
        int i = 0, r = 0;
        while (i < n)
        {
            if (nums[i] == key)
            {
                int l = Math.Max(r, i - k);
                r = Math.Min(n - 1, i + k) + 1;
                for (int j = l; j < r; j++)
                {
                    ret.Add(j);
                }
            }
            i++;
        }
        return ret;
    }
}