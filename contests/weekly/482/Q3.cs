public class Solution
{
    public int MinAllOneMultiple(int k)
    {
        // s = s * 10 + 1 mod k == 0
        // 2, 4, 5, 6, 8
        // 1, 3, 7, 9
        if (k % 2 == 0 || k % 5 == 0) return -1;
        long s = 0;
        HashSet<long> seen = [];
        int count = 0;
        while (seen.Add(s))
        {
            s = (s * 10 + 1) % k;
            count++;
        }
        if (s == 0) return count;
        return -1;
    }
}
