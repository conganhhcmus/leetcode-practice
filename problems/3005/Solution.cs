public class Solution
{
    public int MaxFrequencyElements(int[] nums)
    {
        int ans = 0;
        int maxFreq = 0;
        int[] count = new int[101];
        foreach (int num in nums)
        {
            count[num]++;
            if (count[num] > maxFreq)
            {
                maxFreq = count[num];
                ans = count[num];
            }
            else if (count[num] == maxFreq)
            {
                ans += count[num];
            }
        }
        return ans;
    }
}