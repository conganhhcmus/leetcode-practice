public class Solution
{
    public bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        var arr1 = coordinate1.ToCharArray();
        var arr2 = coordinate2.ToCharArray();

        var result = arr1[0] + arr1[1] - arr2[0] - arr2[1];
        return result % 2 == 0;
    }
}