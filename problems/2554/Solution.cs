public class Solution
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        HashSet<int> set = [.. banned];
        int count = 0;
        for (int i = 1; i <= n && maxSum > 0 && maxSum - i >= 0; i++)
        {
            if (!set.Contains(i))
            {
                maxSum -= i;
                count++;
            }
        }

        return count;
    }
}