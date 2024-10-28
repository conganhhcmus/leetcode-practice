namespace Problem_2501;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [4, 3, 6, 16, 8, 2];
        var solution = new Solution();
        Console.WriteLine(solution.LongestSquareStreak(nums));
    }
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