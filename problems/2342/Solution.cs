public class Solution
{
    public int MaximumSum(int[] nums)
    {
        int n = nums.Length;
        // max value is 10^9, so max sum of digits is 9x10 = 90
        int[] map = new int[91];
        Array.Fill(map, int.MinValue / 2);
        map[SumOfDigit(nums[0])] = nums[0];
        int ans = -1;
        for (int i = 1; i < n; i++)
        {
            int key = SumOfDigit(nums[i]);
            ans = Math.Max(ans, map[key] + nums[i]);

            // update the map
            map[key] = Math.Max(map[key], nums[i]);
        }
        return ans;
    }

    private int SumOfDigit(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}