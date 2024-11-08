using System.Runtime.Intrinsics.X86;

namespace Problem_1318;

public class Solution
{
    public static void Execute()
    {
        int a = 2;
        int b = 6;
        int c = 5;
        var solution = new Solution();
        Console.WriteLine(solution.MinFlips(a, b, c));
    }
    public int MinFlips(int a, int b, int c)
    {
        int diffBits = (a | b) ^ c;
        int flipCount = int.PopCount(diffBits);
        while (diffBits > 0)
        {
            if ((diffBits & 1) != 0)
            {
                flipCount += ((a & 1) + (b & 1)) / 2;
            }
            diffBits >>= 1;
            a >>= 1;
            b >>= 1;
        }
        return flipCount;
    }
}