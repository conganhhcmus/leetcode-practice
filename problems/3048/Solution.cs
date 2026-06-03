public class Solution
{
    public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
    {
        int n = nums.Length, m = changeIndices.Length;
        int low = 1, high = m, ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;

        bool Ok(int k)
        {
            int cnt = 0;
            HashSet<int> marks = [];
            for (int s = k; s > 0; s--)
            {
                int idx = changeIndices[s - 1] - 1;
                if (marks.Add(idx))
                {
                    cnt += nums[idx];
                    if (s <= cnt) return false;
                }
                else cnt--;
                cnt = Math.Max(0, cnt);
            }
            return marks.Count == n;
        }
    }
}
