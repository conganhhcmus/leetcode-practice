namespace Problem_69;
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int x = 4;
        Console.WriteLine(solution.MySqrt(x));
    }
    public int MySqrt(int x)
    {
        if (x == 0 || x == 1) return x;
        int left = 1, right = x;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if ((x / mid) < mid)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return right;
    }
}