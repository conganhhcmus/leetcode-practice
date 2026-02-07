public class Solution
{
    IList<IList<int>> ret = [];
    public IList<IList<int>> Subsets(int[] nums)
    {
        Backtracking(nums, 0, []);
        return ret;
    }

    void Backtracking(int[] nums, int start, IList<int> curr)
    {
        if (start <= nums.Length)
        {
            ret.Add([.. curr]);
        }
        for (int i = start; i < nums.Length; i++)
        {
            curr.Add(nums[i]);
            Backtracking(nums, i + 1, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}