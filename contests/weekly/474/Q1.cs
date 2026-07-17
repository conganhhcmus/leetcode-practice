public class Solution
{
    public IList<int> FindMissingElements(int[] nums)
    {
        int max = nums[0], min = nums[0];
        bool[] seen = new bool[101];
        foreach (int x in nums)
        {
            if (max < x) max = x;
            if (min > x) min = x;
            seen[x] = true;
        }
        List<int> ans = [];
        for (int x = min; x <= max; x++)
        {
            if (!seen[x]) ans.Add(x);
        }
        return ans;
    }
}
