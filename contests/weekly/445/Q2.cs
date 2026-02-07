public class Solution
{
    public string SmallestPalindrome(string s)
    {
        int n = s.Length;
        int len = n / 2;
        char[] prefix = s.Substring(0, len).ToCharArray();
        Array.Sort(prefix);
        string mid = (n % 2 == 0) ? "" : s[n / 2].ToString();
        string ret = new(prefix);
        ret += mid;
        Array.Reverse(prefix);
        ret += new string(prefix);
        return ret;
    }
}