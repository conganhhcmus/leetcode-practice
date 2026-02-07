public class Solution
{
    public bool PrimeSubOperation(int[] nums)
    {
        int prev = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = nums[i] - prev - 1; j >= 2; j--)
            {
                if (IsPrimeNumber(j))
                {
                    nums[i] -= j;
                    break;
                }
            }
            prev = nums[i];
        }

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1]) return false;
        }
        return true;
    }

    private bool IsPrimeNumber(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}