#if DEBUG
namespace Contests_438_Q1;
#endif

public class Solution
{
    public bool HasSameDigits(string s)
    {
        while (s.Length > 2)
        {
            s = Compute(s);
        }

        return s[0] == s[1];
    }

    string Compute(string s)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length - 1; i++)
        {
            sb.Append(((s[i] - '0') + (s[i + 1] - '0')) % 10);
        }
        return sb.ToString();
    }
}