public class Solution
{
    public int GetLucky(string s, int k)
    {
        var temp = Convert(s);
        return Transform(temp, k);
    }

    public string Convert(string s)
    {
        var value = 1;
        for (var i = 'a'; i <= 'z'; i++)
        {
            s = s.Replace(i.ToString(), value.ToString());
            value++;
        }

        return s;
    }

    public int Transform(string s, int k)
    {
        if (k <= 0) return int.Parse(s);

        var sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
            sum += int.Parse(s[i].ToString());
        }

        return Transform(sum.ToString(), k - 1);
    }
}