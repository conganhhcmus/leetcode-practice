using System.Text;

public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        StringBuilder sb = new StringBuilder();
        int idx1 = 0;
        int idx2 = 0;
        while (idx1 < s.Length && idx2 < spaces.Length)
        {
            if (idx1 == spaces[idx2])
            {
                sb.Append(" ");
                idx2++;
            }
            sb.Append(s[idx1]);
            idx1++;
        }

        while (idx1 < s.Length)
        {
            sb.Append(s[idx1]);
            idx1++;
        }

        return sb.ToString();
    }
}