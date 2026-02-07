public class Solution
{
    public int MaxRepeating(string sequence, string word)
    {
        int n = sequence.Length, m = word.Length;
        int k = n / m;
        while (k > 0)
        {
            string newWord = new(Enumerable.Repeat(word.ToCharArray(), k).SelectMany(x => x).ToArray());
            if (sequence.Contains(newWord)) return k;
            k--;
        }
        return k;
    }
}