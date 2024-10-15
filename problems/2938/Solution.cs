namespace Problem_2938;

public class Solution
{
    public static void Execute()
    {
        string s = "11000111";
        var solution = new Solution();
        Console.WriteLine(solution.MinimumSteps(s));
    }
    public long MinimumSteps(string s)
    {
        char[] balls = s.ToCharArray();

        long count = 0;
        long ans = 0;
        for (int i = balls.Length - 1; i >= 0; i--)
        {
            if (balls[i] == '0') count++;
            else ans += count;
        }

        return ans;
    }
}