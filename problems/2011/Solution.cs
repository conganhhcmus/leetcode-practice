#if DEBUG
namespace Problems_2011;
#endif

public class Solution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        int ans = 0;
        foreach (string op in operations)
        {
            if (op == "X++" || op == "++X")
            {
                ans++;
            }
            else
            {
                ans--;
            }
        }

        return ans;
    }
}