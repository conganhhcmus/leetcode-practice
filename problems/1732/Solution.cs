public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int sum = 0;
        for (int i = 0; i < gain.Length; i++)
        {
            sum += gain[i];
            max = Math.Max(max, sum);
        }

        return max;
    }
}