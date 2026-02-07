public class Solution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        int n = s.Length, m = shifts.Length;
        char[] map = new char[26];
        for (char ch = 'a'; ch <= 'z'; ch++) map[ch - 'a'] = ch;
        int[] lines = new int[n + 1];
        for (int i = 0; i < m; i++)
        {
            int l = shifts[i][0], r = shifts[i][1], d = shifts[i][2];
            if (d == 0)
            {
                lines[l] -= 1;
                lines[r + 1] += 1;
            }
            else
            {
                lines[l] += 1;
                lines[r + 1] -= 1;
            }
        }
        int changed = 0;
        char[] chars = s.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            changed += lines[i];
            int idx = (chars[i] - 'a' + (changed % 26) + 26) % 26;
            chars[i] = map[idx];
        }

        return new string(chars);
    }
}