#if DEBUG
namespace Problems_28;
#endif

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack[i] != needle[0]) continue;
            bool found = true;
            for (int j = 0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                {
                    found = false;
                    break;
                }
            }
            if (found) return i;
        }

        return -1;
    }
}