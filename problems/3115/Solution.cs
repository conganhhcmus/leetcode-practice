public class Solution
{
    public int MaximumPrimeDifference(int[] nums)
    {
        bool[] isPrime = new bool[101];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i < 101; i++)
        {
            if (isPrime[i])
            {
                for (int j = i + i; j < 101; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }
        int ans = 0;
        int first = -1;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (isPrime[nums[i]])
            {
                if (first != -1)
                {
                    ans = Math.Max(ans, i - first);
                }
                else first = i;
            }
        }
        return ans;
    }
}
