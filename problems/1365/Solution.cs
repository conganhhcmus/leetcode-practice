public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int n = nums.Length;
        int[] count = new int[101];
        foreach (int num in nums)
        {
            count[num]++;
        }
        int[] fn = new int[101];
        int sum = 0;
        for (int i = 0; i < 101; i++)
        {
            fn[i] = sum;
            sum += count[i];
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            res[i] = fn[nums[i]];
        }
        return res;
    }
}