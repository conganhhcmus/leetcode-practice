#if DEBUG
namespace Problems_2206;
#endif

public class Solution
{
    public bool DivideArray(int[] nums)
    {
        int n = nums.Length;
        int[] freq = new int[501];
        for (int i = 0; i < n; i++)
        {
            freq[nums[i]]++;
        }

        for (int i = 0; i < 501; i++)
        {
            if (freq[i] % 2 != 0) return false;
        }
        return true;
    }
}