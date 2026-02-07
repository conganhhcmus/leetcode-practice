public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int[] line = new int[n + 2];
        foreach (int[] query in queries)
        {
            int start = query[0], end = query[1];
            line[start]++;
            line[end + 1]--;
        }
        int curr = 0;
        for (int i = 0; i < n; i++)
        {
            curr += line[i];
            if (curr < nums[i]) return false;
        }
        return true;
    }
}