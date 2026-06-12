public class Solution
{
    public long LastInteger(long n)
    {
        long head = 1;
        long step = 1;
        long remain = n;
        bool left = true;

        while (remain > 1)
        {
            if (!left && (remain & 1) == 0)
                head += step;

            step <<= 1;
            remain = (remain + 1) >> 1;
            left = !left;
        }

        return head;
    }
}
