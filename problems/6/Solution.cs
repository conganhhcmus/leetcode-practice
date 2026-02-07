public class Solution
{
    public string Convert(string s, int numRows)
    {
        string[] res = new string[numRows];
        int rowIndex = 0;
        bool isIncreasing = true;
        for (int i = 0; i < s.Length; i++)
        {
            res[rowIndex] += s[i];

            rowIndex += isIncreasing ? 1 : -1;

            if (rowIndex >= numRows)
            {
                rowIndex -= Math.Min(2, numRows);
                isIncreasing = false;
            }

            if (rowIndex < 0)
            {
                rowIndex += Math.Min(2, numRows);
                isIncreasing = true;
            }
        }
        return string.Join("", res);
    }
}