public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        int n = nums.Length;
        Array.Sort(nums);
        IList<IList<int>> ans = [];

        for (int a = 0; a < n; a++)
        {
            if (a > 0 && nums[a] == nums[a - 1]) continue;
            for (int b = a + 1; b < n; b++)
            {
                if (b > a + 1 && nums[b] == nums[b - 1]) continue;
                int left = b + 1;
                int right = n - 1;
                while (left < right)
                {
                    int[] val = [nums[a], nums[b], nums[left], nums[right]];
                    long sum = 0L + nums[a] + nums[b] + nums[left] + nums[right];
                    if (sum == target) ans.Add(val);
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
            }
        }

        return ans;
    }
}