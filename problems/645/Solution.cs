public class Solution
{
    public int[] FindErrorNums(int[] nums)
    {
        int n = nums.Length;
        bool[] seen = new bool[n + 1];
        int p1 = -1, p2 = -1;
        foreach (int num in nums)
        {
            if (seen[num])
            {
                p1 = num;
            }
            seen[num] = true;
        }

        for (int i = 1; i <= n; i++)
        {
            if (!seen[i])
            {
                p2 = i;
                break;
            }
        }
        return [p1, p2];
    }
}