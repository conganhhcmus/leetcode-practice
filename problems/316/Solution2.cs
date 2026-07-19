public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        int n = s.Length;
        int[] suffixMask = new int[n + 1];
        suffixMask[n] = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            suffixMask[i] = suffixMask[i + 1] | (1 << (s[i] - 'a'));
        }

        int remainMask = suffixMask[0];
        int start = 0;
        StringBuilder sb = new();
        while (remainMask != 0)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                int bit = 1 << (c - 'a');
                if ((remainMask & bit) == 0) continue;
                int need = remainMask ^ bit;
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
                if ((suffixMask[pos + 1] & need) == need)
                {
                    sb.Append(c);
                    start = pos;
                    remainMask = need;
                    break;
                }
            }
        }
        return sb.ToString();
    }
}
