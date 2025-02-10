#if DEBUG
namespace Problems_3174;
#endif

public class Solution
{
    public string ClearDigits(string s)
    {
        StringBuilder sb = new();
        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            }
            else sb.Append(c);
        }
        return sb.ToString();
    }
}