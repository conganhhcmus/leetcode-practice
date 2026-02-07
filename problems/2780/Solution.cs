public class Solution
{
    public int MinimumIndex(IList<int> nums)
    {
        int n = nums.Count;
        int x = nums[0];
        Dictionary<int, int> freq = [];
        foreach (int num in nums)
        {
            freq.TryAdd(num, 0);
            freq[num]++;
            if (freq[x] < freq[num])
            {
                x = num;
            }
        }

        int[] prefixCount = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixCount[i + 1] = prefixCount[i] + (nums[i] == x ? 1 : 0);
        }
        for (int i = 0; i < n; i++)
        {
            if (Ok(prefixCount, i)) return i;
        }
        return -1;
    }

    bool Ok(int[] prefixCount, int mid)
    {
        int n = prefixCount.Length - 1;
        int leftCount = prefixCount[mid + 1];
        int rightCount = prefixCount[n] - leftCount;
        return (2 * leftCount > mid + 1) && (2 * rightCount > n - mid - 1);
    }
}