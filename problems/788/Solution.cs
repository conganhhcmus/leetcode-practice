public class Solution
{
    public int RotatedDigits(int n)
    {
        int count = 0;
        for (int i = 0; i <= n; i++)
        {
            if (Ok(i)) count++;
        }
        return count;

        bool Ok(int k)
        {
            bool hasDiff = false;
            while (k > 0)
            {
                int d = k % 10;
                if (d == 3 || d == 4 || d == 7) return false;
                if (d == 2 || d == 5 || d == 6 || d == 9) hasDiff = true;
                k /= 10;
            }

            return hasDiff;
        }
    }
}
