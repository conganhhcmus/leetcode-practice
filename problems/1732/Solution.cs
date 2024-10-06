namespace Problem_1732;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] gain = [2, 1, 5, 3, 6, 4, 8, 9, 7];
        Console.WriteLine(solution.LargestAltitude(gain));
    }
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int sum = 0;
        for (int i = 0; i < gain.Length; i++)
        {
            sum += gain[i];
            max = Math.Max(max, sum);
        }

        return max;
    }
}