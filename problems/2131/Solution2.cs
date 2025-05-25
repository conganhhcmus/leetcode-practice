#if DEBUG
namespace Problems_2131_2;
#endif

public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        int ret = 0;
        int[,] count = new int[26, 26];

        foreach (string word in words)
        {
            int a = word[0] - 'a', b = word[1] - 'a';
            if (count[b, a] != 0)
            {
                ret += 4;
                count[b, a]--;
            }
            else
            {
                count[a, b]++;
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i, i] != 0)
            {
                ret += 2;
                break;
            }
        }
        return ret;
    }
}