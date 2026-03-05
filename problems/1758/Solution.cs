public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        // opt1: odd is 0 and even is 1
        // opt2: odd is 1 and even is 0
        int opt1 = 0, opt2 = 0;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                if (s[i] == '0') opt1++;
                else opt2++;
            }
            else
            {
                if (s[i] == '1') opt1++;
                else opt2++;
            }
        }

        return Math.Min(opt1, opt2);
    }
}