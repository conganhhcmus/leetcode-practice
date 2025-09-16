#if DEBUG
namespace Problems_2197;
#endif

public class Solution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        int n = nums.Length;
        Stack<int> stack = [];
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            while (stack.Count > 0)
            {
                int gcd = Gcd(stack.Peek(), num);
                if (gcd == 1) break;
                num = (int)(1L * num * stack.Pop() / gcd);
            }
            stack.Push(num);
        }
        List<int> ans = [];
        while (stack.Count > 0)
        {
            ans.Add(stack.Pop());
        }
        ans.Reverse();
        return ans;
    }

    int Gcd(int a, int b)
    {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }
}