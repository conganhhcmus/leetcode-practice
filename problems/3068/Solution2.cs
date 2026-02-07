public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long ret = 0;
        int cnt = 0;
        int remain = int.MaxValue;
        foreach (int num in nums)
        {
            ret += Math.Max(num ^ k, num);
            if ((num ^ k) > num) cnt++;
            remain = Math.Min(remain, Math.Abs(num - (num ^ k)));
        }
        return ret - (cnt % 2) * remain;
    }
}