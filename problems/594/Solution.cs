public class Solution
{
    public int FindLHS(int[] nums)
    {
        Dictionary<int, int> count = [];
        foreach (int num in nums)
        {
            count[num] = count.GetValueOrDefault(num, 0) + 1;
        }
        int ret = 0;
        foreach (int num in count.Keys)
        {
            ret = Math.Max(ret, count[num] + count.GetValueOrDefault(num - 1, int.MinValue));
        }
        return ret;
    }
}