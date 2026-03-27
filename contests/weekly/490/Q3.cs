public class Solution
{
    public string MaximumXor(string s, string t)
    {
        StringBuilder sb = new();
        int countZero = 0, countOne = 0;
        foreach (char c in t)
        {
            if (c == '0') countZero++;
            else countOne++;
        }
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
            {
                if (countZero > 0)
                {
                    countZero--;
                    sb.Append('1');
                }
                else
                {
                    countOne--;
                    sb.Append('0');
                }
            }
            else
            {
                if (countOne > 0)
                {
                    countOne--;
                    sb.Append('1');
                }
                else
                {
                    countZero--;
                    sb.Append('0');
                }
            }
        }
        return sb.ToString();
    }
}