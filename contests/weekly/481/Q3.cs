public class Solution
{
    public int MinSwaps(int[] nums, int[] forbidden)
    {
        int n = nums.Length;
        Dictionary<int, int> cnt1 = [], cnt2 = [];
        foreach (int num in nums) cnt1[num] = cnt1.GetValueOrDefault(num, 0) + 1;
        foreach (int num in forbidden) cnt2[num] = cnt2.GetValueOrDefault(num, 0) + 1;
        foreach (var kv in cnt1)
        {
            if (kv.Value + cnt2.GetValueOrDefault(kv.Key, 0) > n) return -1;
        }
        Dictionary<int, int> bads = [];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == forbidden[i])
            {
                bads[nums[i]] = bads.GetValueOrDefault(nums[i], 0) + 1;
            }
        }
        int maxBad = 0, sumBad = 0;
        foreach (int val in bads.Values)
        {
            maxBad = Math.Max(maxBad, val);
            sumBad += val;
        }
        return Math.Max((sumBad + 1) / 2, maxBad);
    }
}
