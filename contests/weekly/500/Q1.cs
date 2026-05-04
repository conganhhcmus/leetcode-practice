public class Solution
{
    public int[] CountOppositeParity(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            int parity = nums[i] % 2;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] % 2 != parity)
                {
                    count++;
                }
            }
            ans[i] = count;
        }
        return ans;
    }
}
