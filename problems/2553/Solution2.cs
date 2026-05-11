public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        List<int> ans = [];
        int n = nums.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            int t = nums[i];
            while (t > 0)
            {
                ans.Add(t % 10);
                t /= 10;
            }
        }
        ans.Reverse();
        return ans.ToArray();
    }
}
