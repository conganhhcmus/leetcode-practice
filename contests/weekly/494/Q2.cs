public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        int INF = int.MaxValue;
        int minOdd = INF, minEven = INF;
        foreach (int num in nums1)
        {
            if (num % 2 == 1)
            {
                if (minOdd > num) minOdd = num;
            }
            else
            {
                if (minEven > num) minEven = num;
            }
        }
        if (minOdd == INF) return true;
        return minEven > minOdd;
    }
}