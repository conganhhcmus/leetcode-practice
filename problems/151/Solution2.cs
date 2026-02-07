public class Solution
{
    public int ReverseWords(char[] s)
    {
        int n = s.Length;

        // Step 1: Clean spaces
        int index = CleanSpaces(s, n);

        // Step 2: Reverse the whole string
        Reverse(s, 0, index - 1);

        // Step 3: Reverse each word
        ReverseEachWord(s, index);
        return index;
    }

    private int CleanSpaces(char[] s, int n)
    {
        int i = 0, j = 0;

        while (j < n)
        {
            // Skip spaces
            while (j < n && s[j] == ' ') j++;

            // Keep non-space characters
            while (j < n && s[j] != ' ')
            {
                s[i++] = s[j++];
            }

            // Skip spaces between words
            while (j < n && s[j] == ' ') j++;

            // Add a single space if not at the end
            if (j < n) s[i++] = ' ';
        }

        return i; // new valid length
    }

    private void Reverse(char[] s, int left, int right)
    {
        while (left < right)
        {
            char temp = s[left];
            s[left++] = s[right];
            s[right--] = temp;
        }
    }

    private void ReverseEachWord(char[] s, int n)
    {
        int start = 0, end = 0;

        while (start < n)
        {
            while (end < n && s[end] != ' ') end++;

            Reverse(s, start, end - 1);

            start = end + 1;
            end = start;
        }
    }
}
