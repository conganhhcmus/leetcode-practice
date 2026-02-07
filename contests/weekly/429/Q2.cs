public class Solution
{
    public int MaxDistinctElements(int[] nums, int k)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                nums[i] -= k;
            }
            else
            {
                nums[i] = Math.Max(nums[i] - k, Math.Min(nums[i - 1] + 1, nums[i] + k));
            }
        }
        return CountDistinctElements(nums);
    }

    private int CountDistinctElements(int[] nums)
    {
        HashSet<int> set = [];
        foreach (int num in nums)
        {
            set.Add(num);
        }
        return set.Count;
    }
}