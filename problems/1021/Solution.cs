public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder sb = new();
        int bal = 0;
        foreach (char c in s)
        {
            if (c == '(') bal++;
            else bal--;
            if (c == '(' && bal == 1) continue;
            if (c == ')' && bal == 0) continue;
            sb.Append(c);
        }
        return sb.ToString();
    }
}