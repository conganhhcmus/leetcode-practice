public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (Compare(arr[i], arr[j]) > 0)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }
        return arr;
    }

    int Compare(int a, int b)
    {
        int count1 = PopCount(a);
        int count2 = PopCount(b);
        if (count1 == count2) return a - b;
        return count1 - count2;
    }

    int PopCount(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
}