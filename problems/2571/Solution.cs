public class Solution
{
    public int MinOperations(int n)
    {
        List<int> bits = [];
        while (n > 0)
        {
            bits.Add(n & 1);
            n >>= 1;
        }
        bits.Add(0);
        int ans = 0;
        int count = 0;
        for (int i = 0; i < bits.Count; i++)
        {
            if (bits[i] == 0)
            {
                ans += Math.Min(count, 1);
                if (count > 1) count = 1;
                else count = 0;
            }
            else
            {
                count++;
            }
        }
        if (count > 0) ans += count;
        return ans;
    }
}