#if DEBUG
namespace Problems_22;
#endif

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> ans = [];
        Generate(ans, "", 0, 0, n);
        return ans;
    }

    private void Generate(List<string> ans, string cur, int open, int close, int max)
    {
        if (cur.Length == max * 2)
        {
            ans.Add(cur);
            return;
        }

        if (open < max) Generate(ans, cur + "(", open + 1, close, max);
        if (close < open) Generate(ans, cur + ")", open, close + 1, max);
    }
}