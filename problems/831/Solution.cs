using System.Text.RegularExpressions;

public class Solution
{
    public string MaskPII(string s)
    {
        s = s.ToLower();
        int index = s.IndexOf('@');
        if (index >= 0)
        {
            return string.Format("{0}*****{1}", s[0], s[(index - 1)..]);
        }
        else
        {
            s = Regex.Replace(s, @"\D", "");
            string local = string.Format("***-***-{0}", s[(s.Length - 4)..]);
            if (s.Length == 10) return local;
            string ans = "+";
            for (int i = 0; i < s.Length - 10; i++)
            {
                ans += "*";
            }
            return ans + "-" + local;
        }
    }
}