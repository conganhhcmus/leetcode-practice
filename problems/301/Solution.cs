using System.Text;

public class Solution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        HashSet<string> ans = [];
        int miniumRemoved = int.MaxValue;
        Recurse(s, 0, 0, 0, new(), 0);

        return ans.ToList();

        void Recurse(string s, int idx, int leftCnt, int rightCnt, StringBuilder sb, int delCnt)
        {
            if (idx == s.Length)
            {
                if (leftCnt == rightCnt)
                {
                    if (delCnt <= miniumRemoved)
                    {
                        string candidate = sb.ToString();
                        if (delCnt < miniumRemoved)
                        {
                            ans.Clear();
                            miniumRemoved = delCnt;
                        }

                        ans.Add(candidate);
                    }
                }
                return;
            }

            char c = s[idx];
            if (c != '(' && c != ')')
            {
                sb.Append(c);
                Recurse(s, idx + 1, leftCnt, rightCnt, sb, delCnt);
                sb.Length--;
            }
            else
            {
                // del it
                Recurse(s, idx + 1, leftCnt, rightCnt, sb, delCnt + 1);
                sb.Append(c);

                // keep it
                if (c == '(')
                {
                    Recurse(s, idx + 1, leftCnt + 1, rightCnt, sb, delCnt);
                }
                else if (rightCnt < leftCnt)
                {
                    Recurse(s, idx + 1, leftCnt, rightCnt + 1, sb, delCnt);
                }
                sb.Length--;
            }
        }
    }
}
