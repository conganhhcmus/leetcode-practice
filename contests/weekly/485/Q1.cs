public class Solution
{
    public int VowelConsonantScore(string s)
    {
        int c = 0, v = 0;
        foreach (char ch in s)
        {
            if (ch == ' ' || char.IsDigit(ch)) continue;
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u') v++;
            else c++;
        }
        if (c > 0) return v / c;
        return 0;
    }
}
