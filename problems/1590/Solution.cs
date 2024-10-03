namespace Problem_1590;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [3, 1, 4, 2];
        int p = 6;
        var solution = new Solution();
        Console.WriteLine(solution.MinSubarray(nums, p));
    }
    public int MinSubarray(int[] nums, int p)
    {
        int totalMod = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            totalMod = (totalMod + nums[i] % p) % p;
        }

        if (totalMod == 0) return 0;

        int currMod = 0;
        int ans = nums.Length;
        Dictionary<int, int> mapMod = [];
        mapMod[0] = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            currMod = (currMod + nums[i]) % p;

            int needed = (currMod - totalMod + p) % p;

            if (mapMod.TryGetValue(needed, out int value))
            {
                ans = Math.Min(ans, i - value);
            }

            mapMod[currMod] = i;
        }
        return ans == nums.Length ? -1 : ans;
    }
}