public class Solution
{
    public bool ValidDigit(int n, int x)
    {
        string str = n.ToString();
        char c = (char)('0' + x);
        return str.Contains(c) && str[0] != c;
    }
}
