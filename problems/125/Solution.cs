public class Solution
{
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (!IsLetter(s[left]))
            {
                left++;
                continue;
            }
            if (!IsLetter(s[right]))
            {
                right--;
                continue;
            }

            if (ToLower(s[left]) != ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    private bool IsLetter(char c) => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');

    private char ToLower(char c) => (c < 'a') ? (char)(c + 'a' - 'A') : c;
}