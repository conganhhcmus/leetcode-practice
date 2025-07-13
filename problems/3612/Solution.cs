#if DEBUG
namespace Problems_3612;
#endif

public class Solution
{
    public string ProcessStr(string s)
    {
        StringBuilder sb = new();
        foreach (char c in s)
        {
            if (c == '#')
            {
                // dup
                int len = sb.Length;
                for (int i = 0; i < len; i++)
                {
                    sb.Append(sb[i]);
                }
            }
            else if (c == '%')
            {
                // reverse
                int len = sb.Length;
                for (int i = 0; i < len / 2; i++)
                {
                    (sb[i], sb[len - i - 1]) = (sb[len - i - 1], sb[i]);
                }
            }
            else if (c == '*')
            {
                if (sb.Length > 0) sb.Length--;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}