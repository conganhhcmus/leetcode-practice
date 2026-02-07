public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        int[] freq = new int[26];
        foreach (char c in tiles) freq[c - 'A']++;
        return BackTracking(freq);
    }

    private int BackTracking(int[] freq)
    {
        int count = 0;
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] == 0) continue;
            count++;
            freq[i]--;
            count += BackTracking(freq);
            freq[i]++;
        }

        return count;
    }
}