public class Solution
{
    public int MinElement(int[] nums)
    {
        int min = int.MaxValue;
        foreach (int num in nums)
        {
            int sum = 0;
            int tmp = num;
            while (tmp > 0)
            {
                sum += tmp % 10;
                tmp /= 10;
            }
            if (min > sum) min = sum;
        }
        return min;
    }
}
