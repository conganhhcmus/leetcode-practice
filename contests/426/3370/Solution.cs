namespace Problem_3370;
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int n = 10;
        Console.WriteLine(solution.SmallestNumber(n));
    }
    public int SmallestNumber(int n)
    {
        int i = 1;
        while (i < n)
        {
            n |= i;
            i <<= 1;
        }
        return n;
    }
}