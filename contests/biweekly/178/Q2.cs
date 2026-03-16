public class Solution
{
    public long GcdSum(int[] nums)
    {
        int n = nums.Length;
        int[] prefix = new int[n];
        int max = nums[0];
        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, nums[i]);
            prefix[i] = Gcd(nums[i], max);
        }
        Array.Sort(prefix);
        int l = 0, r = n - 1;
        long sum = 0;
        while (l < r)
        {
            sum += Gcd(prefix[l], prefix[r]);
            l++;
            r--;
        }
        return sum;
    }

    int Gcd(int a, int b)
    {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }
}