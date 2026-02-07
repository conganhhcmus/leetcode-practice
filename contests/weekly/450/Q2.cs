public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;
        int[] clone = new int[n];
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++)
        {
            map[nums[i]] = i;
        }
        Array.Copy(nums, clone, n);
        Array.Sort(clone, (a, b) =>
        {
            int sum1 = SumDigit(a);
            int sum2 = SumDigit(b);
            if (sum1 == sum2) return a - b;
            return sum1 - sum2;
        });
        int ret = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] != clone[i])
            {
                int a = i;
                int b = map[clone[i]];
                (nums[i], nums[map[clone[i]]]) = (nums[map[clone[i]]], nums[i]);
                // update map
                map[nums[a]] = a;
                map[nums[b]] = b;

                ret++;
            }
        }

        return ret;
    }

    int SumDigit(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}