public class Solution
{
    public int[] RearrangeArray(int[] nums)
    {
        int n = nums.Length;
        List<int> pos = [];
        List<int> neg = [];
        foreach (int num in nums)
        {
            if (num >= 0)
            {
                pos.Add(num);
            }
            else
            {
                neg.Add(num);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                nums[i] = pos[i / 2];
            }
            else
            {
                nums[i] = neg[i / 2];
            }
        }
        return nums;
    }
}