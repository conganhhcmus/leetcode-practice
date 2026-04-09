public class Solution
{
    public int MinAbsoluteDifference(IList<int> nums, int x)
    {
        int n = nums.Count;
        List<int> list = new();
        int ans = int.MaxValue;

        for (int i = x; i < n; i++)
        {
            int pos = list.BinarySearch(nums[i - x]);
            if (pos < 0) pos = ~pos;
            list.Insert(pos, nums[i - x]);

            int idx = list.BinarySearch(nums[i]);

            if (idx < 0) idx = ~idx;

            if (idx < list.Count)
                ans = Math.Min(ans, Math.Abs(list[idx] - nums[i]));

            if (idx > 0)
                ans = Math.Min(ans, Math.Abs(list[idx - 1] - nums[i]));
        }

        return ans;
    }
}