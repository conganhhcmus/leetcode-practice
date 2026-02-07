public class Solution
{
    public int SumFourDivisors(int[] nums)
    {
        int ans = 0;
        foreach (int num in nums)
        {
            ans += Sum(num);
        }

        return ans;
    }

    int Sum(int num)
    {
        HashSet<int> divisors = [1, num];
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                divisors.Add(i);
                divisors.Add(num / i);
            }
        }

        if (divisors.Count != 4) return 0;

        return divisors.Sum();
    }
}