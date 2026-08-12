public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        int low = 1, high = num;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            long val = 1L * mid * mid;
            if (val == num) return true;
            if (val > num)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return false;
    }
}
