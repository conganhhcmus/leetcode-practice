public class Solution
{
    public int CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int pos = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == k)
            {
                pos = i;
                break;
            }
        }

        Dictionary<int, int> count = [];
        int balance = 0;
        count[0] = 1;
        for (int i = pos - 1; i >= 0; i--)
        {
            if (nums[i] > k) balance++;
            else balance--;
            count[balance] = count.GetValueOrDefault(balance) + 1;
        }

        balance = 0;
        int ans = 0;
        for (int i = pos; i < n; i++)
        {
            // prefix == suffix
            // prefix - 1 == suffix
            if (i > pos)
            {
                if (nums[i] > k) balance++;
                else balance--;
            }
            ans += count.GetValueOrDefault(-balance);
            ans += count.GetValueOrDefault(1 - balance);
        }
        return ans;
    }
}