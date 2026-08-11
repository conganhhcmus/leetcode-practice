public class Solution
{
    public int MissingInteger(int[] nums)
    {
        int n = nums.Length;
        int sum = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] == nums[i - 1] + 1) sum += nums[i];
            else break;
        }
        HashSet<int> all = [.. nums];
        while (all.Contains(sum)) sum++;
        return sum;
    }
}
