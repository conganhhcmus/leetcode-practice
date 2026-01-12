#if DEBUG
namespace Problems_65;
#endif

public class Solution
{
    public bool IsNumber(string s)
    {
        s = s.ToLower();

        bool seenDigit = false;
        bool seenDot = false;
        bool seenE = false;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (char.IsDigit(c))
            {
                seenDigit = true;
            }
            else if (c == '+' || c == '-')
            {
                if (i != 0 && s[i - 1] != 'e') return false;
            }
            else if (c == '.')
            {
                if (seenDot || seenE) return false;
                seenDot = true;
            }
            else if (c == 'e')
            {
                if (seenE || !seenDigit) return false;
                seenE = true;
                seenDigit = false; // must see digit after e
            }
            else
            {
                return false;
            }
        }

        return seenDigit;
    }
}