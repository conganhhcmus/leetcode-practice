namespace Practice_539;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        IList<string> timePoints = ["05:31", "22:08", "00:35"];
        Console.WriteLine(solution.FindMinDifference(timePoints));
    }
    public int FindMinDifference(IList<string> timePoints)
    {
        if (timePoints.Count > 24 * 60) return 0;

        bool[] dp = new bool[24 * 60];
        foreach (var timePoint in timePoints)
        {
            int h = int.Parse(timePoint[..2]);
            int m = int.Parse(timePoint[3..]);
            int min = h * 60 + m;
            if (dp[min])
            {
                return 0;
            }
            dp[min] = true;
        }

        int prevIndex = int.MaxValue;
        int firstIndex = int.MaxValue;
        int lastIndex = int.MaxValue;
        int ans = int.MaxValue;

        for (int i = 0; i < 24 * 60; i++)
        {
            if (dp[i])
            {
                if (prevIndex != int.MaxValue)
                {
                    ans = int.Min(ans, i - prevIndex);
                }
                prevIndex = i;
                if (firstIndex == int.MaxValue)
                {
                    firstIndex = i;
                }
                lastIndex = i;
            }
        }

        return int.Min(ans, 24 * 60 - lastIndex + firstIndex);
    }
}