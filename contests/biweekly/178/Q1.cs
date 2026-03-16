public class Solution
{
    public int FirstUniqueEven(int[] nums)
    {
        int[] count = new int[101];
        for (int i = 0; i < nums.Length; i++)
        {
            count[nums[i]]++;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0 && count[nums[i]] == 1) return nums[i];
        }
        return -1;
    }
}