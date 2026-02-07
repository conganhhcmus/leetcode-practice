public class Solution
{
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
    {
        int ret = 0;
        ret += Math.Min(k, numOnes);
        k -= numOnes;
        k -= numZeros;
        ret -= Math.Min(Math.Max(0, k), numNegOnes);
        return ret;
    }
}