public class Solution
{
    public int SplitNum(int num)
    {
        int[] count = new int[10];
        while (num > 0)
        {
            int d = num % 10;
            count[d]++;
            num /= 10;
        }
        bool pick = true;
        int a = 0;
        int b = 0;
        for (int i = 0; i < 10; i++)
        {
            while (count[i] > 0)
            {
                if (pick) a = a * 10 + i;
                else b = b * 10 + i;
                count[i]--;
                pick = !pick;
            }
        }
        return a + b;
    }
}