public class Solution
{
    public int[] MinOperations(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        List<int> arr = [];
        for (int i = 0; i <= 5000; i++)
        {
            if (Ok(i)) arr.Add(i);
        }
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            int low = 0, high = arr.Count - 1, best = 0;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (arr[mid] <= x)
                {
                    best = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            int l = arr[best];
            int r = best + 1 < arr.Count ? arr[best + 1] : int.MaxValue;
            ans[i] = Math.Min(x - l, r - x);
        }
        return ans;

        bool Ok(int n)
        {
            List<int> bits = [];
            while (n > 0)
            {
                bits.Add(n & 1);
                n >>= 1;
            }
            for (int i = 0; i < bits.Count / 2; i++)
            {
                if (bits[i] != bits[bits.Count - 1 - i]) return false;
            }
            return true;
        }
    }
}
