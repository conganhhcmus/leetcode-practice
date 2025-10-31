#if DEBUG
namespace Problems_3289;
#endif

public class Solution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        int n = nums.Length;
        int[] count = new int[n];
        int[] ans = new int[2];
        int i = 0;
        foreach (int num in nums)
        {
            count[num]++;
            if (count[num] > 1)
            {
                ans[i++] = num;
            }
            if (i == 2) break;
        }

        return ans;
    }
}