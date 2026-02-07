public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        return kSum(nums, target, 0, 4);
    }

    private IList<IList<int>> kSum(int[] nums, long target, int start, int k)
    {
        IList<IList<int>> ans = [];
        int n = nums.Length;
        if (start == n) return ans;
        long avg = target / k;
        if (nums[start] > avg || avg > nums[n - 1]) return ans;
        if (k == 2) return TwoSum(nums, target, start);
        for (int i = start; i < n; i++)
        {
            if (i > start && nums[i] == nums[i - 1]) continue;
            long nTarget = target - nums[i];
            var values = kSum(nums, nTarget, i + 1, k - 1);
            foreach (var value in values)
            {
                ans.Add([nums[i], .. value]);
            }
        }

        return ans;
    }

    private IList<IList<int>> TwoSum(int[] nums, long target, int start)
    {
        IList<IList<int>> ans = [];
        int n = nums.Length;
        if (start == n) return ans;
        int left = start;
        int right = n - 1;
        while (left < right)
        {
            long sum = 0L + nums[left] + nums[right];
            if (sum == target) ans.Add([nums[left], nums[right]]);
            if (sum > target)
            {
                right--;
                while (right > left && nums[right] == nums[right + 1]) right--; // remove duplicate
            }
            else
            {
                left++;
                while (left < right && nums[left] == nums[left - 1]) left++; // remove duplicate
            }
        }

        return ans;
    }
}