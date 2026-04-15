public class Solution
{
    public int ReversePairs(int[] nums)
    {
        int n = nums.Length;
        return Merge(nums, 0, n - 1);
    }

    int Merge(int[] nums, int l, int r)
    {
        if (l >= r)
            return 0;
        int m = l + (r - l) / 2;
        int lcount = Merge(nums, l, m);
        int rcount = Merge(nums, m + 1, r);
        int count = 0;
        int i = l;
        int j = m + 1;
        while (i <= m)
        {
            while (j <= r && nums[i] > 2L * nums[j])
                j++;
            count += j - (m + 1);
            i++;
        }

        int k = r - l + 1;
        int[] tmp = new int[k];
        i = l;
        j = m + 1;
        int idx = 0;
        while (i <= m && j <= r)
        {
            if (nums[i] < nums[j])
            {
                tmp[idx++] = nums[i];
                i++;
            }
            else
            {
                tmp[idx++] = nums[j];
                j++;
            }
        }

        while (i <= m)
        {
            tmp[idx++] = nums[i++];
        }
        while (j <= r)
        {
            tmp[idx++] = nums[j++];
        }

        for (int t = l; t <= r; t++)
        {
            nums[t] = tmp[t - l];
        }

        return count + lcount + rcount;
    }
}
