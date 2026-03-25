public class Solution
{
    public int[] MinDistinctFreqPair(int[] nums)
    {
        int[] freq = new int[101];
        foreach (int num in nums)
        {
            freq[num]++;
        }
        for (int x = 0; x <= 100; x++)
        {
            if (freq[x] == 0) continue;
            for (int y = x + 1; y <= 100; y++)
            {
                if (freq[y] == 0) continue;
                if (freq[y] != freq[x]) return [x, y];
            }
        }
        return [-1, -1];
    }
}