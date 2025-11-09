#if DEBUG
namespace Problems_2169;
#endif

public class Solution
{
    public int CountOperations(int num1, int num2)
    {
        int ans = 0;
        if (num2 == 0) return 0;
        if (num1 >= num2)
        {
            ans += num1 / num2;
            num1 = num1 % num2;
        }

        return ans + CountOperations(num2, num1);
    }
}