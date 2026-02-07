public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        HashSet<char> broken = [];
        foreach (char c in brokenLetters)
        {
            broken.Add(c);
        }
        string[] words = text.Split(" ");
        int ans = words.Length;
        foreach (string word in words)
        {
            bool isBroken = false;
            foreach (char c in word)
            {
                if (broken.Contains(c))
                {
                    isBroken = true;
                    break;
                }
            }
            if (isBroken) ans--;
        }

        return ans;
    }
}