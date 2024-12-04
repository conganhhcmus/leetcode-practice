#if DEBUG
namespace Problems_2825;
#endif

public class Solution
{
    public bool CanMakeSubsequence(string str1, string str2)
    {
        int idx1 = 0, idx2 = 0;
        while (idx1 < str1.Length && idx2 < str2.Length)
        {
            if ((str2[idx2] - str1[idx1] + 26) % 26 < 2)
            {
                idx1++;
                idx2++;
            }
            else
            {
                idx1++;
            }
        }

        return idx2 == str2.Length;
    }
}