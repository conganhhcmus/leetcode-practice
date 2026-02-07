public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int count = 0;
        foreach (int num in nums)
        {
            int length = (int)Math.Log10(num) + 1;
            if (length % 2 == 0) count++;
        }
        return count;
    }
}