#if DEBUG
namespace Problems_47_2;
#endif

public class Solution
{
    IList<IList<int>> ret = [];

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);
        Dfs(nums, 0, []);
        return ret;
    }

    void Dfs(int[] nums, int k, IList<int> curr)
    {
        if (k == nums.Length)
        {
            ret.Add(curr);
            return;
        }
        else
        {
            for (int i = 0; i < k + 1; i++)
            {
                if (i == 0 || (i > 0 && nums[k] != curr[i - 1]))
                {
                    var next = curr.ToList();
                    next.Insert(i, nums[k]);
                    Dfs(nums, k + 1, next);
                }
                else return;
            }
        }
    }
}