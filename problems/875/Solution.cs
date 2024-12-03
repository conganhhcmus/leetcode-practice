namespace Problem_875;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        bool CanEatAllBanana(int k)
        {
            int hourSpent = 0;
            foreach (int pile in piles)
            {
                hourSpent += (int)Math.Ceiling((double)pile / k);
                if (hourSpent > h) return false;
            }

            return true;
        }

        int left = 1;
        int right = 0;
        foreach (int pile in piles)
        {
            right = Math.Max(right, pile);
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanEatAllBanana(mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return right;
    }
}