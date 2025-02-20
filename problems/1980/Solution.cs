#if DEBUG
namespace Problems_1980;
#endif

public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        int n = nums[0].Length;
        int maxVal = (1 << n) - 1;
        bool[] map = new bool[maxVal + 1];
        foreach (string num in nums)
        {
            map[Convert.ToInt32(num, 2)] = true;
        }

        for (int i = 0; i <= maxVal; i++)
        {
            if (!map[i]) return IntToBinaryString(i, n);
        }
        return IntToBinaryString(maxVal, n);
    }

    private string IntToBinaryString(int num, int len)
    {
        StringBuilder sb = new();
        for (int i = len - 1; i >= 0; i--)
        {
            sb.Append((num & (1 << i)) != 0 ? 1 : 0);
        }

        return sb.ToString();
    }

    private int BinaryStringToInt(string str)
    {
        int ans = 0;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] == '1') ans |= (1 << (str.Length - 1 - i));
        }

        return ans;
    }
}