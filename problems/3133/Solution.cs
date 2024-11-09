namespace Problem_3133;

public class Solution
{
    public static void Execute()
    {
        int n = 3;
        int x = 4;
        var solution = new Solution();
        Console.WriteLine(solution.MinEnd(n, x));
    }
    public long MinEnd(int n, int x)
    {
        long result = x;
        long remaining = n - 1;
        long position = 1;

        while (remaining != 0)
        {
            if ((x & position) == 0)
            {
                result |= (remaining & 1) * position;
                remaining >>= 1;
            }
            position <<= 1;
        }

        return result;
    }
}