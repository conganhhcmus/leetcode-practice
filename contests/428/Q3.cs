#if DEBUG
namespace Contests_428_Q3;
#endif

public class Solution
{
    public int BeautifulSplits(int[] nums)
    {
        int n = nums.Length;
        int[][] lcps = new int[n][];
        for (int x = 0; x < n; ++x)
        {
            lcps[x] = new int[n];
            var lcp = lcps[x];
            int max_i = x, max_r = x;
            for (int i = x + 1; i < n; ++i)
            {
                if (max_r >= i)
                {
                    lcp[i] = Math.Min(max_r - i + 1, lcp[i - max_i + x]);
                }
                while (i + lcp[i] < n && nums[i + lcp[i]] == nums[x + lcp[i]]) ++lcp[i];
                if (i + lcp[i] - 1 > max_r)
                {
                    max_i = i;
                    max_r = i + lcp[i] - 1;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n - 1; ++j)
            {
                if (lcps[0][i + 1] >= i + 1 && j - i >= i + 1)
                {
                    ++ans;
                    continue;
                }
                if (lcps[i + 1][j + 1] >= j - i)
                {
                    ++ans;
                    continue;
                }
            }
        }

        return ans;
    }
}