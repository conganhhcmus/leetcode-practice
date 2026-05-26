public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        HashSet<char> seen = [.. word];
        int count = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            if (seen.Contains(c) && seen.Contains((char)(c - 'a' + 'A')))
            {
                count++;
            }
        }
        return count;
    }
}
