public class Solution
{
    public string ProcessStr(string s)
    {
        StringBuilder sb = new();
        foreach (char c in s)
        {
            if (c == '#') sb.Append(sb);
            else if (c == '%')
            {
                // reverse
                int len = sb.Length;
                for (int i = 0; i < len / 2; i++)
                {
                    (sb[i], sb[len - i - 1]) = (sb[len - i - 1], sb[i]);
                }
            }
            else if (c == '*') sb.Length = Math.Max(0, sb.Length - 1);
            else sb.Append(c);
        }

        return sb.ToString();
    }
}
