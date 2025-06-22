#if DEBUG
namespace Problems_2138;
#endif

public class Solution
{
    public string[] DivideString(string s, int k, char fill)
    {
        int n = s.Length;
        int need = (k - n % k) % k;
        s += new string(fill, need);
        int len = (n + k - 1) / k;
        string[] ret = new string[len];
        for (int i = 0, j = 0; i < len; i++, j += k)
        {
            ret[i] = s[j..(j + k)];
        }
        return ret;
    }
}