public class Solution
{
    public int SortableIntegers(int[] nums)
    {
        int n = nums.Length;
        HashSet<int> candidates = [];
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                candidates.Add(i);
                candidates.Add(n / i);
            }
        }
        int sum = 0;
        foreach (int k in candidates)
        {
            if (IsOk(k, nums)) sum += k;
        }

        return sum;
    }

    bool IsOk(int k, int[] nums)
    {
        int n = nums.Length;
        int prev = 0;
        for (int i = 0; i < n / k; i++)
        {
            int st = i * k;
            int ed = st + k - 1;
            if (!CanCycle(st, ed, nums)) return false;
            int min = int.MaxValue;
            int max = 0;
            for (int j = st; j <= ed; j++)
            {
                min = Math.Min(min, nums[j]);
                max = Math.Max(max, nums[j]);
            }
            if (min < prev) return false;
            prev = max;
        }
        return true;
    }

    bool CanCycle(int st, int ed, int[] nums)
    {
        int n = ed - st + 1;
        int[] arr = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = nums[st + i];
            arr[i + n] = nums[st + i];
        }
        int max = 1;
        int count = 1;
        for (int i = 1; i < 2 * n; i++)
        {
            if (arr[i] >= arr[i - 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            max = Math.Max(max, count);
        }
        return max >= n;
    }
}