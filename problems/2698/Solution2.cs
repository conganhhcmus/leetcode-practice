#if DEBUG
namespace Problems_2698_2;
#endif

public class Solution
{
    public int PunishmentNumber(int n)
    {
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            int square = i * i;
            if (Ok(square, i)) ans += square;
        }

        return ans;
    }

    private bool Ok(int num, int target)
    {
        if (num == target) return true;
        Stack<(int, int)> stack = [];
        stack.Push((num, target));
        while (stack.Count > 0)
        {
            var (currNum, currTarget) = stack.Pop();
            for (int power = 10; power < currNum; power *= 10)
            {
                int take = currNum % power;
                int remain = currNum / power;
                int newTarget = currTarget - take;
                if (remain == newTarget) return true;
                if (newTarget > 0 && remain > newTarget)
                {
                    stack.Push((remain, newTarget));
                }
            }
        }

        return false;
    }
}