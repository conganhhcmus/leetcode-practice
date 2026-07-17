public class Solution
{
    public int MinMoves(int[] nums)
    {
        int M = 0;
        foreach (int x in nums) if (M < x) M = x;
        int ans = 0;
        foreach (int x in nums) ans += M - x;

        return ans;
    }
}
