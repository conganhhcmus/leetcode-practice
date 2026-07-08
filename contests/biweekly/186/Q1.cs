public class Solution
{
    public bool IsMiddleElementUnique(int[] nums)
    {
        int[] cnt = new int[101];
        foreach (int x in nums) cnt[x]++;

        return cnt[nums[nums.Length / 2]] == 1;
    }
}
