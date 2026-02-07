public class Solution
{
    public int MaxDiff(int num)
    {
        string minNum = num.ToString();
        string maxNum = num.ToString();
        foreach (char d in maxNum)
        {
            if (d != '9')
            {
                maxNum = maxNum.Replace(d, '9');
                break;
            }
        }
        for (int i = 0; i < minNum.Length; i++)
        {
            char d = minNum[i];
            if (i == 0)
            {
                if (d != '1')
                {
                    minNum = minNum.Replace(d, '1');
                    break;
                }
            }
            else
            {
                if (d != '0' && d != minNum[0])
                {
                    minNum = minNum.Replace(d, '0');
                    break;
                }
            }
        }

        return int.Parse(maxNum) - int.Parse(minNum);
    }
}