public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int[] f = new int[128];
        int[] l = new int[128];
        Array.Fill(f, -1);
        Array.Fill(l, -1);
        int n = word.Length;
        for (int i = 0; i < n; i++)
        {
            char c = word[i];
            if (f[c] == -1) f[c] = i;
            l[c] = i;
        }
        int count = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            char C = (char)(c - 'a' + 'A');
            if (f[c] == -1 || f[C] == -1 || l[c] > f[C]) continue;
            count++;
        }
        return count;
    }
}
