public class Solution
{
    public int MinimumFlips(int n)
    {
        List<int> bits = [];
        while (n > 0)
        {
            bits.Add(n & 1);
            n >>= 1;
        }
        int ans = 0;
        for (int i = 0; i < bits.Count; i++)
        {
            if (bits[i] != bits[bits.Count - 1 - i]) ans++;
        }
        return ans;
    }
}
