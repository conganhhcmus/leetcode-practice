public class Solution
{
    public int CountTriples(int n)
    {
        int count = 0;
        for (int a = 1; a <= n; a++)
        {
            for (int b = 1; b <= n; b++)
            {
                int val = a * a + b * b;
                int c = (int)Math.Sqrt(val);
                if (c <= n && c * c == val)
                {
                    count++;
                }
            }
        }
        return count;
    }
}