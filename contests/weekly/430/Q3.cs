#if DEBUG
namespace Contests_430_Q3;
#endif

public class Solution
{
    public long NumberOfSubsequences(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        Dictionary<double, int> map = [];
        map[(double)nums[0] / nums[2]] = 1;
        for (int r = 4; r < n - 2; r++)
        {
            for (int s = r + 2; s < n; s++)
            {
                double key = (double)nums[s] / nums[r];
                ans += map.GetValueOrDefault(key, 0);
            }

            for (int p = r - 3, q = r - 1; p >= 0; p--)
            {
                double key = (double)nums[p] / nums[q];
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }
        }

        return ans;
    }
}