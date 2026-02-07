public class Solution
{
    public int Maximum69Number(int num)
    {
        char[] digits = num.ToString().ToCharArray();
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] == '6')
            {
                digits[i] = '9';
                break;
            }
        }

        int ans = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            ans = ans * 10 + (digits[i] - '0');
        }
        return ans;
    }
}