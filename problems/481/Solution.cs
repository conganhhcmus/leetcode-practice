public class Solution
{
    public int MagicalString(int n)
    {
        if (n == 0)
            return 0;
        if (n < 3)
            return 1;
        List<int> s = [1, 2, 2];
        int i = 2;
        int num = 1;
        int count = 1;
        while (s.Count < n)
        {
            int times = s[i];
            for (int k = 0; k < times; k++)
            {
                if (num == 1 && s.Count < n)
                    count++;
                s.Add(num);
            }
            num = 3 - num;
            i++;
        }
        return count;
    }
}
