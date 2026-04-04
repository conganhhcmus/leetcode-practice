public class Solution
{
    public bool RepeatedSubstringPattern(string s)
    {
        string doubled = s + s;
        string trimmed = doubled[1..^1];
        return trimmed.Contains(s);
    }
}