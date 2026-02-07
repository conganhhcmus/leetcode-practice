public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int count = 0;
        int n = s.Length;
        int[] lastPos = new int[3];
        Array.Fill(lastPos, -1);
        for (int pos = 0; pos < n; pos++)
        {
            lastPos[s[pos] - 'a'] = pos;
            count += 1 + Math.Min(lastPos[0], Math.Min(lastPos[1], lastPos[2]));
        }
        return count;
    }
}