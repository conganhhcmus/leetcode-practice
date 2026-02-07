public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> hashSet = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (!hashSet.Add(nums[i])) return true;
        }
        return false;
    }
}