namespace Problem_1545;

public class Solution
{
    public char FindKthBit(int n, int k)
    {
        string Si = "0";
        for (int i = 0; i < n && Si.Length < k; i++)
        {
            var tmp = Si.ToCharArray();
            for (var j = 0; j < tmp.Length; j++)
            {
                tmp[j] = tmp[j] == '0' ? '1' : '0';
            }
            Si += "1" + string.Join("", tmp.Reverse());
        }
        return Si[k - 1];
    }
}