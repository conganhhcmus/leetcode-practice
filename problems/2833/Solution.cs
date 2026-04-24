public class Solution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        int n = moves.Length;
        int countL = 0, countR = 0;
        foreach (char c in moves)
        {
            if (c == 'L') countL++;
            else if (c == 'R') countR++;
        }

        return Math.Max(Math.Abs(n - 2 * countR), Math.Abs(n - 2 * countL));
    }
}
