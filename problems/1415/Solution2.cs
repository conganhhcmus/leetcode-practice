#if DEBUG
namespace Problems_1415_2;
#endif

public class Solution
{
    public string GetHappyString(int n, int k)
    {
        int total = 3 * (1 << (n - 1));
        if (k > total) return string.Empty;

        StringBuilder sb = new StringBuilder();
        int curr = 0;
        for (int i = 0; i < 3; i++)
        {
            if (curr + (1 << (n - 1)) >= k)
            {
                sb.Append((char)(i + 'a'));
                break;
            }
            curr += (1 << (n - 1));
        }

        for (int i = 1; i < n; i++)
        {
            if (curr + (1 << (n - i - 1)) >= k)
            {
                sb.Append(sb[^1] == 'a' ? 'b' : 'a');
            }
            else
            {
                sb.Append(sb[^1] == 'c' ? 'b' : 'c');
                curr += (1 << (n - i - 1));
            }
        }

        return sb.ToString();
    }
}