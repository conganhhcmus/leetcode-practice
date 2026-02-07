public class Solution
{
    public int HIndex(int[] citations)
    {
        Array.Sort(citations, (a, b) => b - a);
        int ans = 0;
        while (ans < citations.Length && citations[ans] >= (ans + 1))
        {
            ans++;
        }
        return ans;
    }

    private int HIndex_Enhance(int[] citations)
    {
        var counts = new int[citations.Length + 1];

        foreach (var c in citations)
        {
            if (c >= citations.Length)
            {
                ++counts[citations.Length];
            }
            else
            {
                ++counts[c];
            }
        }

        int cumCit = 0;
        for (int i = citations.Length; i >= 0; --i)
        {
            cumCit += counts[i];
            if (cumCit >= i)
            {
                return i;
            }
        }

        return 0;
    }
}