namespace Problem_7;

public class Solution
{
    public int Reverse(int x)
    {
        var str = x.ToString().ToCharArray();
        var sign = "";
        if (str[0] == '-')
        {
            sign = "-";
            str = str[1..str.Length];
        }
        Array.Reverse(str);
        //Console.WriteLine(sign + string.Concat(str));
        return int.TryParse(sign + string.Concat(str), out var value) ? value : 0;
    }
}