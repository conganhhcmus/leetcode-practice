namespace Problem_1071;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string str1 = "ABCABC";
        string str2 = "ABC";
        Console.WriteLine(solution.GcdOfStrings(str1, str2));
    }
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1) return "";

        return str1[0..GCD(str1.Length, str2.Length)];
    }

    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}