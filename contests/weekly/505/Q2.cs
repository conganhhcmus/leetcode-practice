using System.Text;

public class Solution
{
    public IList<string> GenerateValidStrings(int n, int k)
    {
        IList<string> ans = [];

        Solve(0, k, new());
        return ans;

        void Solve(int pos, int cost, StringBuilder sb)
        {
            if (cost < 0) return;
            if (pos >= n)
            {
                ans.Add(sb.ToString());
                return;
            }
            // set it
            if (sb.Length == 0 || sb[^1] == '0')
            {
                Solve(pos + 1, cost - pos, sb.Append('1'));
                sb.Length--;
            }
            // dont set it
            Solve(pos + 1, cost, sb.Append('0'));
            sb.Length--;
        }
    }
}
