namespace Problem_1413;

public class Solution
{
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