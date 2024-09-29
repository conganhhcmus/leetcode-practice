namespace Problem_1413;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] candies = [2, 3, 5, 1, 3];
        int extraCandies = 3;
        var result = solution.KidsWithCandies(candies, extraCandies);
        Console.WriteLine($"[{string.Join(",", result)}]");
    }
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> ans = [];
        int maxCandies = candies.Max();
        for (int i = 0; i < candies.Length; i++)
        {
            ans.Add(candies[i] + extraCandies >= maxCandies);
        }

        return ans;
    }
}