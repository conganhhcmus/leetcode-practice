#if DEBUG
namespace Problems_3314;
#endif

public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        int n = nums.Count;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = -1;
            for (int j = 0; j < nums[i]; j++)
            {
                if ((j | (j + 1)) == nums[i])
                {
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
}