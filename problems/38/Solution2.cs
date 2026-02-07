public class Solution
{
    public string CountAndSay(int n)
    {
        string ret = "1";
        if (n == 1) return ret;
        for (int i = 1; i < n; i++)
        {
            StringBuilder sb = new();
            int count = 1;
            for (int j = 1; j < ret.Length; j++)
            {
                if (ret[j] == ret[j - 1]) count++;
                else
                {
                    sb.Append($"{count}{ret[j - 1]}");
                    count = 1;
                }
            }
            sb.Append($"{count}{ret[^1]}");
            ret = sb.ToString();
        }
        return ret;
    }
}