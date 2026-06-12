public class Solution
{
    public int MinOperations(int[] nums)
    {
        int[] cnt = new int[100_001];
        int n = nums.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            int x = nums[i];
            cnt[x]++;
            if (cnt[x] > 1) return (i / 3) + 1;
        }
        return 0;
    }
}
