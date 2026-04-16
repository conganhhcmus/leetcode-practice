public class Solution
{
    public int CountDigitOccurrences(int[] nums, int digit)
    {
        int[] count = new int[10];
        foreach (int num in nums)
        {
            int tmp = num;
            while (tmp > 0)
            {
                count[tmp % 10]++;
                tmp /= 10;
            }
        }

        return count[digit];
    }
}
