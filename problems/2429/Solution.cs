public class Solution
{
    public int MinimizeXor(int num1, int num2)
    {
        int count = 0;
        while (num2 > 0)
        {
            count += num2 & 1;
            num2 >>= 1;
        }
        num2 = num1;
        while (num2 > 0)
        {
            count -= num2 & 1;
            num2 >>= 1;
        }

        if (count == 0) return num1;
        int idx = 0;
        if (count < 0)
        {
            while (count < 0 && idx < 32)
            {
                if ((num1 & (1 << idx)) != 0)
                {
                    num1 &= ~(1 << idx);
                    count++;
                }
                idx++;
            }
            return num1;
        }

        while (count > 0 && idx < 32)
        {
            if ((num1 & (1 << idx)) == 0)
            {
                num1 |= 1 << idx;
                count--;
            }
            idx++;
        }
        return num1;
    }
}