public class Solution
{
    public int LargestCombination(int[] candidates)
    {
        int[] mapBits = new int[24]; // 10^7 ~ 24 bits

        for (int i = 0; i < candidates.Length; i++)
        {
            for (int j = 0; j < mapBits.Length; j++)
            {
                mapBits[j] += ((candidates[i] & (1 << j)) != 0) ? 1 : 0;
            }
        }

        int max = 0;
        for (int i = 0; i < mapBits.Length; i++)
        {
            max = Math.Max(max, mapBits[i]);
        }

        return max;
    }
}