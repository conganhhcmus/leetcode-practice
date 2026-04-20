public class Solution
{
    public int LongestSubsequence(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        bool[][] mask = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            mask[i] = new bool[32];
            for (int j = 0; j < 32; j++)
            {
                if ((nums[i] & (1 << j)) != 0)
                {
                    mask[i][j] = true;
                }
            }
        }
        for (int bit = 0; bit < 32; bit++)
        {
            ans = Math.Max(ans, LIS(nums, bit, mask));
        }
        return ans;
    }

    int LIS(int[] nums, int bit, bool[][] mask)
    {
        int n = nums.Length;
        List<int> tail = [];
        for (int i = 0; i < n; i++)
        {
            if (!mask[i][bit]) continue;
            int x = nums[i];
            int l = 0, r = tail.Count - 1, p = tail.Count;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (tail[m] >= x)
                {
                    p = m;
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            if (p == tail.Count)
            {
                tail.Add(x);
            }
            else
            {
                tail[p] = x;
            }
        }

        return tail.Count;
    }
}
