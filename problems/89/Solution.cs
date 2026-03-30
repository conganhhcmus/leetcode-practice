public class Solution
{
    public IList<int> GrayCode(int n)
    {
        /*
            gray(i) = i ^ (i >> 1)
            gray(i) ^ gray(i+1) = 2^k
        */
        int[] result = new int[1 << n];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = i ^ (i >> 1);
        }
        return result;
    }
}