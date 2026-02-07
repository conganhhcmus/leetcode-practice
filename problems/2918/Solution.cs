public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        int countZero1 = 0;
        long sum1 = 0;
        foreach (int num in nums1)
        {
            if (num == 0) countZero1++;
            sum1 += num;
        }

        int countZero2 = 0;
        long sum2 = 0;
        foreach (int num in nums2)
        {
            if (num == 0) countZero2++;
            sum2 += num;
        }

        long min1 = sum1 + countZero1;
        long max1 = countZero1 > 0 ? long.MaxValue : min1;
        long min2 = sum2 + countZero2;
        long max2 = countZero2 > 0 ? long.MaxValue : min2;
        if (max2 < min1 || max1 < min2) return -1;
        return Math.Max(min1, min2);
    }
}