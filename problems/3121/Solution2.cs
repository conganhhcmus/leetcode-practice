public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int[] state = new int[26];
        foreach (char c in word)
        {
            if (char.IsLower(c))
            {
                int idx = c - 'a';
                if (state[idx] == 0) state[idx] = 1;
                else if (state[idx] == 2) state[idx] = 3;
            }
            else
            {
                int idx = c - 'A';
                if (state[idx] == 0) state[idx] = 3;
                else if (state[idx] == 1) state[idx] = 2;
            }
        }
        int count = 0;
        for (int i = 0; i < 26; i++)
        {
            if (state[i] == 2) count++;
        }
        return count;
    }
}
