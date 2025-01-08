#if DEBUG
namespace Problems_228;
#endif

public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0) return [];
        IList<string> ans = [];
        int n = nums.Length;
        int st = nums[0], count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != st + count)
            {
                if (count == 1) ans.Add(st.ToString());
                else ans.Add($"{st}->{st + count - 1}");
                st = nums[i];
                count = 0;
            }

            count++;
        }

        if (count == 1) ans.Add(st.ToString());
        else ans.Add($"{st}->{st + count - 1}");

        return ans;
    }
}