public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int n = nums.Length;
        int MAX = 2 * limit + 2;
        int[] diff = new int[MAX];
        for (int i = 0; i < n / 2; i++)
        {
            int min = Math.Min(nums[i], nums[n - 1 - i]);
            int max = Math.Max(nums[i], nums[n - 1 - i]);
            int val = nums[i] + nums[n - 1 - i];
            diff[2] += 2;
            diff[min + 1] -= 1;
            diff[max + limit + 1] += 1;
            diff[val] -= 1;
            diff[val + 1] += 1;
        }

        int ans = n;
        int sum = 0;
        for (int c = 2; c <= 2 * limit; c++)
        {
            sum += diff[c];
            if (ans > sum) ans = sum;
        }
        return ans;
    }
}
