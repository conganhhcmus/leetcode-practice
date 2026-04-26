public class Solution
{
    public int CompareBitonicSums(int[] nums)
    {
        int n = nums.Length;
        int i = 0;
        while (i < n - 1 && nums[i] < nums[i + 1]) i++;
        long sum = 0;
        for (int j = 0; j <= i; j++)
        {
            sum += nums[j];
        }
        for (int j = i; j < n; j++)
        {
            sum -= nums[j];
        }
        if (sum == 0) return -1;
        if (sum > 0) return 0;
        return 1;
    }
}
