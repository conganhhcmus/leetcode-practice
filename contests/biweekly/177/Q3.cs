public class Solution
{
    public int[] MakeParityAlternating(int[] nums)
    {
        int n = nums.Length;
        int ops0 = 0, ops1 = 0;
        for (int i = 0; i < n; i++)
        {
            int parity = Math.Abs(nums[i] % 2);
            if (parity != i % 2) ops0++;
            if (parity != (i + 1) % 2) ops1++;
        }
        int minOps = Math.Min(ops1, ops0);
        int minDiff = int.MaxValue;
        if (minOps == ops0)
        {
            minDiff = Math.Min(minDiff, MinDiff(nums, 0));
        }

        if (minOps == ops1)
        {
            minDiff = Math.Min(minDiff, MinDiff(nums, 1));
        }

        return [minOps, minDiff];
    }

    int MinDiff(int[] nums, int p)
    {
        int n = nums.Length;
        List<int[]> arr = [];
        for (int i = 0; i < n; i++)
        {
            int parity = Math.Abs(nums[i] % 2);
            if (parity != (i + p) % 2)
            {
                arr.Add([nums[i] - 1, i]);
                arr.Add([nums[i] + 1, i]);
            }
            else
            {
                arr.Add([nums[i], i]);
            }
        }

        arr.Sort((a, b) => a[0] - b[0]);
        int unique = 0;
        int minDiff = int.MaxValue;
        int[] count = new int[n];
        for (int r = 0, l = 0; r < arr.Count; r++)
        {
            int idx = arr[r][1];
            if (count[idx] == 0)
            {
                unique++;
            }
            count[idx]++;
            while (unique == n)
            {
                minDiff = Math.Min(minDiff, arr[r][0] - arr[l][0]);
                count[arr[l][1]]--;
                if (count[arr[l][1]] == 0) unique--;
                l++;
            }
        }
        return minDiff;
    }
}