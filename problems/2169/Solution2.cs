public class Solution
{
    public int CountOperations(int num1, int num2)
    {
        int ans = 0;
        while (num1 != 0 && num2 != 0)
        {
            ans += num1 / num2;
            num1 %= num2;
            (num1, num2) = (num2, num1);
        }
        return ans;
    }
}