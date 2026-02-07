public class Solution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);
        int ret = 0;
        for (int i = 0, j = 0; i < s.Length && j < g.Length; i++)
        {
            if (s[i] >= g[j])
            {
                ret++;
                j++;
            }
        }
        return ret;
    }
}