namespace Problems_191;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int n = 2147483645;
        Console.WriteLine(solution.HammingWeight(n));
    }
    public int HammingWeight(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans += n & 1;
            n >>= 1;
        }

        return ans;
    }
}