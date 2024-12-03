namespace Problem_2490;

public class Solution
{
    public bool IsCircularSentence(string sentence)
    {
        if (sentence[0] != sentence[^1]) return false;
        for (int i = 1; i < sentence.Length - 1; i++)
        {
            if (sentence[i] == ' ' && sentence[i + 1] != sentence[i - 1]) return false;
        }

        return true;
    }
}