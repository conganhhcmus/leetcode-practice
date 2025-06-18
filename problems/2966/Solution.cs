#if DEBUG
namespace Problems_2966;
#endif

public class Solution
{
    public int[][] DivideArray(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int[][] ret = new int[n / 3][];
        for (int i = 0; i < n / 3; i++)
        {
            ret[i] = new int[3];
            for (int j = 0; j < 3; j++)
            {
                ret[i][j] = nums[i * 3 + j];
            }
            if (ret[i][2] - ret[i][0] > k) return [];
        }

        return ret;
    }
}