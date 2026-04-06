public class Solution
{
    public int WaysToMakeFair(int[] nums)
    {
        int n = nums.Length;
        int[] odd = new int[n + 1];
        int[] even = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            odd[i] = odd[i - 1] + ((i % 2 == 1) ? nums[i - 1] : 0);
            even[i] = even[i - 1] + ((i % 2 == 0) ? nums[i - 1] : 0);
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            // pick i as removed element
            int prevOdd = odd[i];
            int prevEven = even[i];

            int nextEven = odd[n] - odd[i + 1];
            int nextOdd = even[n] - even[i + 1];

            if (prevOdd + nextOdd == prevEven + nextEven) ans++;
        }
        return ans;
    }
}