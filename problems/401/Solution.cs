public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> ans = [];
        for (int h = 0; h < 12; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                if (BitCount(h) + BitCount(m) == turnedOn)
                {
                    ans.Add(h + ":" + ((m < 10) ? "0" : "") + m);
                }
            }
        }
        return ans;
    }

    int BitCount(int n)
    {
        int ans = 0;
        while (n > 0)
        {
            ans += n & 1;
            n >>= 1;
        }
        return ans;
    }
}