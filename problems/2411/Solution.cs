public class Solution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int[] suffixOr = new int[n];
        suffixOr[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffixOr[i] = suffixOr[i + 1] | nums[i];
        }

        int[] bits = new int[32];

        for (int i = 0, j = 0; i < n; i++)
        {
            while (j < n && Calc(bits) < suffixOr[i])
            {
                Update(bits, nums[j]);
                j++;
            }
            ans[i] = Math.Max(1, j - i);
            Remove(bits, nums[i]);
        }
        return ans;
    }

    void Update(int[] bits, int val)
    {
        for (int i = 0; i < bits.Length; i++)
        {
            if ((val & (1 << i)) != 0)
            {
                bits[i]++;
            }
        }
    }

    void Remove(int[] bits, int val)
    {
        for (int i = 0; i < bits.Length; i++)
        {
            if ((val & (1 << i)) != 0)
            {
                bits[i]--;
            }
        }
    }

    int Calc(int[] bits)
    {
        int ans = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] > 0)
            {
                ans |= (1 << i);
            }
        }
        return ans;
    }
}