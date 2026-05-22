public class Solution
{
    public int MinOperations(int[] nums, int[] target)
    {
        int n = nums.Length;
        HashSet<int> need = [];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != target[i])
            {
                need.Add(nums[i]);
            }
        }
        return need.Count;
    }
}
