namespace Problem_3274;
public class Solution
{
    public static void Execute()
    {
        var coordinate1 = "a1";
        var coordinate2 = "h3";
        var solution = new Solution();
        var res = solution.CheckTwoChessboards(coordinate1, coordinate2);

        Console.WriteLine(res);
    }
    public bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        var arr1 = coordinate1.ToCharArray();
        var arr2 = coordinate2.ToCharArray();

        var result = arr1[0] + arr1[1] - arr2[0] - arr2[1];
        return result % 2 == 0;
    }
}