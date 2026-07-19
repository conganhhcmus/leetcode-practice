using System.Text;

public class Solution
{
    public string SmallestSubsequence(string s)
    {
        int n = s.Length;
        int[] suffixMask = new int[n + 1];
        suffixMask[n] = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            suffixMask[i] = suffixMask[i + 1] | (1 << (s[i] - 'a'));
        }
        int remainMask = suffixMask[0];
        StringBuilder ans = new();
        int start = 0;
        while (remainMask != 0)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                int bit = 1 << (c - 'a');
                if ((remainMask & bit) == 0) continue;
                int pos = -1;
                for (int i = start; i < n; i++)
                {
                    if (s[i] == c)
                    {
                        pos = i;
                        break;
                    }
                }
                if (pos == -1) continue;
                int need = remainMask ^ bit;
                if ((suffixMask[pos + 1] & need) == need)
                {
                    ans.Append(c);
                    remainMask ^= bit;
                    start = pos + 1;
                    break;
                }
            }
        }
        return ans.ToString();
    }
}
