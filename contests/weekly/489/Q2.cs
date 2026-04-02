public class Solution
{
    public int FirstUniqueFreq(int[] nums)
    {
        int MAX = 100001;
        int[] freq = new int[MAX];
        int[] count = new int[MAX];
        foreach (int n in nums)
        {
            freq[n]++;
        }
        for (int i = 0; i < MAX; i++)
        {
            if (freq[i] > 0)
            {
                count[freq[i]]++;
            }
        }
        foreach (int n in nums)
        {
            if (count[freq[n]] == 1) return n;
        }
        return -1;
    }
}