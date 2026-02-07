public class Solution
{
    public int MinTimeToType(string word)
    {
        int ret = 0;
        char curr = 'a';
        foreach (char c in word)
        {
            int clockwise = Math.Abs(c - curr);
            int counterClockwise = 26 - clockwise;
            ret += Math.Min(clockwise, counterClockwise) + 1;
            curr = c;
        }

        return ret;
    }
}