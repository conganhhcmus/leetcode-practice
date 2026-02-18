public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        List<int> bits = [];
        while (n > 0)
        {
            bits.Add(n & 1);
            n >>= 1;
        }
        for (int i = 1; i < bits.Count; i++)
        {
            if (bits[i] == bits[i - 1]) return false;
        }
        return true;
    }
}