public class Solution
{
    public int MinimumSum(int num)
    {
        int[] digits = new int[4];
        int i = 0;
        while (num > 0)
        {
            digits[i++] = num % 10;
            num /= 10;
        }
        Array.Sort(digits);
        int num1 = digits[0] * 10 + digits[2];
        int num2 = digits[1] * 10 + digits[3];
        return num1 + num2;
    }
}