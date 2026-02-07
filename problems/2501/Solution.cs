public class Solution
{
    public int LongestSquareStreak(int[] nums)
    {
        int ans = -1;
        HashSet<long> set = [.. nums];
        foreach (var num in set)
        {
            int count = 0;
            long tmp = num;
            while (set.Contains(tmp))
            {
                count++;
                tmp *= tmp;
            }

            ans = Math.Max(ans, count);
        }

        return ans < 2 ? -1 : ans;
    }
}