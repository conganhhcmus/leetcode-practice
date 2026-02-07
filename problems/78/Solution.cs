public class Solution
{
    IList<IList<int>> ret = [];
    public IList<IList<int>> Subsets(int[] nums)
    {
        Backtracking(nums, 0, []);
        return ret;
    }

    void Backtracking(int[] nums, int pos, IList<int> curr)
    {
        if (pos == nums.Length)
        {
            ret.Add([.. curr]);
            return;
        }
        Backtracking(nums, pos + 1, curr);
        Backtracking(nums, pos + 1, [.. curr, nums[pos]]);
    }
}