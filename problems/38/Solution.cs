#if DEBUG
namespace Problems_38;
#endif

public class Solution
{
    public string CountAndSay(int n)
    {
        return Solve(n, "1");
    }

    string Solve(int n, string curr)
    {
        if (n == 1) return curr;
        StringBuilder sb = new();
        int count = 1;
        for (int i = 1; i < curr.Length; i++)
        {
            if (curr[i] != curr[i - 1])
            {
                sb.Append($"{count}{curr[i - 1]}");
                count = 1;
            }
            else
            {
                count++;
            }
        }

        sb.Append($"{count}{curr[^1]}");

        return Solve(n - 1, sb.ToString());
    }
}