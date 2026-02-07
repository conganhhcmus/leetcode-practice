public class Solution
{
    public int MaximumSwap(int num)
    {
        char[] digitArr = num.ToString().ToCharArray();
        int maxIndex = -1;
        int swap1 = -1;
        int swap2 = -1;

        for (int i = digitArr.Length - 1; i >= 0; i--)
        {
            if (maxIndex == -1 || digitArr[i] > digitArr[maxIndex])
            {
                maxIndex = i;
            }
            else if (digitArr[i] < digitArr[maxIndex])
            {
                swap2 = i;
                swap1 = maxIndex;
            }
        }
        if (swap1 != -1 && swap2 != -1)
        {
            (digitArr[swap1], digitArr[swap2]) = (digitArr[swap2], digitArr[swap1]);
        }
        return int.Parse(new string(digitArr));
    }
}