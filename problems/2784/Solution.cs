public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length;
        int b = n - 1;
        int[] count = new int[n];
        foreach (int num in nums)
        {
            if (num < 1 || num > b) return false;
            count[num]++;
            if (num != b && count[num] > 1) return false;
        }
        return count[b] == 2;
    }
}
