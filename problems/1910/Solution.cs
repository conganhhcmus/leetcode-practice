public class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        StringBuilder sb = new();
        foreach (char c in s)
        {
            sb.Append(c);
            if (c == part[^1] && IsPostfix(sb, part))
            {
                sb.Remove(sb.Length - part.Length, part.Length);
            }
        }

        return sb.ToString();
    }

    private bool IsPostfix(StringBuilder s, string part)
    {
        if (s.Length < part.Length) return false;
        for (int i = s.Length - 1, j = part.Length - 1; i >= 0 && j >= 0; j--, i--)
        {
            if (s[i] != part[j]) return false;
        }
        return true;
    }
}