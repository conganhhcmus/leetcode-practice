public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        char[] chars = tiles.ToCharArray();
        return Backtracking(chars, 0);
    }

    private int Backtracking(char[] chars, int start)
    {
        int count = 0;
        for (int i = start; i < chars.Length; i++)
        {
            if (HaveDuplicate(chars, start, i)) continue;
            count++;
            (chars[i], chars[start]) = (chars[start], chars[i]);
            count += Backtracking(chars, start + 1);
            (chars[i], chars[start]) = (chars[start], chars[i]);
        }
        return count;
    }

    private bool HaveDuplicate(char[] chars, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (chars[i] == chars[end]) return true;
        }

        return false;
    }
}