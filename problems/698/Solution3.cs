public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        int n = nums.Length;
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        if (sum % k != 0) return false;
        int target = sum / k;
        Array.Sort(nums, (a, b) => b - a);
        int[] subSets = new int[k];
        return BackTracking(subSets, nums, 0, k, target);
    }

    bool BackTracking(int[] subSets, int[] nums, int pos, int k, int target)
    {
        if (pos == nums.Length) return true;
        for (int i = 0; i < k; i++)
        {
            if (subSets[i] + nums[pos] > target) continue;
            if (i > 0 && subSets[i] == subSets[i - 1]) continue;
            subSets[i] += nums[pos];
            if (BackTracking(subSets, nums, pos + 1, k, target)) return true;
            subSets[i] -= nums[pos];
        }
        return false;
    }
}