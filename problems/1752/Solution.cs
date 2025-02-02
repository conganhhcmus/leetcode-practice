#if DEBUG
namespace Problems_1752;
#endif

public class Solution
{
    public bool Check(int[] nums)
    {
        int n = nums.Length;
        int[] clone = [.. nums];
        Array.Sort(clone);
        List<int> posRotates = [];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == clone[0]) posRotates.Add(i);
        }
        foreach (int pos in posRotates)
        {
            bool ans = true;
            for (int i = 0; i < n; i++)
            {
                if (nums[(i + pos) % n] != clone[i])
                {
                    ans = false;
                    break;
                }
            }
            if (ans) return true;
        }

        return false;
    }
}