public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var k = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[k] = nums[i];
                k++;
            }
        }
        return k;
    }
}