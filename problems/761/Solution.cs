public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        int n = s.Length;
        List<string> specialSubstring = [];
        int balanceCount = 0;
        int startIndex = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1') balanceCount++;
            else balanceCount--;
            if (balanceCount == 0)
            {
                string innerSubstring = s[(startIndex + 1)..i];
                innerSubstring = MakeLargestSpecial(innerSubstring);
                specialSubstring.Add("1" + innerSubstring + "0");
                startIndex = i + 1;
            }
        }
        specialSubstring.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));
        return string.Join("", specialSubstring);
    }
}