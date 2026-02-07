public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        int ans = 0;
        int set = 0;
        foreach (char c in brokenLetters)
        {
            set |= 1 << (c - 'a');
        }
        bool broken = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                if (!broken) ans++;
                broken = false;
                continue;
            }

            if (broken) continue;
            if ((set & (1 << (text[i] - 'a'))) != 0)
            {
                broken = true;
            }
        }

        if (!broken) ans++;
        return ans;
    }
}