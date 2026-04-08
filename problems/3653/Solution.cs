public class Solution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int mod = (int)1e9 + 7;
        foreach (int[] q in queries)
        {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            for (int i = l; i <= r; i += k)
            {
                nums[i] = (int)(1L * nums[i] * v % mod);
            }
        }
        int xor = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            xor ^= nums[i];
        }
        return xor;
    }
}