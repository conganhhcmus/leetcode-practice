#if DEBUG
namespace Problems_557;
#endif

public class Solution
{
    public string ReverseWords(string str)
    {
        char[] s = str.ToCharArray();
        int n = s.Length;
        int i = 0;
        while (i < n)
        {
            while (i < n && s[i] == ' ') i++;
            int j = i;
            while (j < n && s[j] != ' ') j++;
            int tmp = j;
            j--;
            while (i < j)
            {
                (s[i], s[j]) = (s[j], s[i]);
                i++;
                j--;
            }
            i = tmp;
        }
        return new(s);
    }
}