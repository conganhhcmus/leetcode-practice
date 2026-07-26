public class Solution
{
    public int MaximumProduct(int[] nums)
    {
        int max1 = int.MinValue;
        int max2 = int.MinValue;
        int max3 = int.MinValue;
        int min1 = int.MaxValue;
        int min2 = int.MaxValue;
        foreach (int x in nums)
        {
            if (x > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = x;
            }
            else if (x > max2)
            {
                max3 = max2;
                max2 = x;
            }
            else if (x > max3)
            {
                max3 = x;
            }
            if (x < min1)
            {
                min2 = min1;
                min1 = x;
            }
            else if (x < min2)
            {
                min2 = x;
            }
        }
        return Math.Max(max1 * max2 * max3, max1 * min1 * min2);
    }
}
