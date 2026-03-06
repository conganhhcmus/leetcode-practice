public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        int n = s.Length;
        // check exist "01" return false
        for (int i = 1; i < n; i++)
        {
            if (s[i] == '1' && s[i - 1] == '0') return false;
        }
        return true;
    }
}