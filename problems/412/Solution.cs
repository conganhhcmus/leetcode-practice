public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        IList<string> ret = new List<string>(n);
        for (int i = 1; i <= n; i++)
        {
            if (i % 15 == 0)
            {
                ret.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                ret.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                ret.Add("Buzz");
            }
            else
            {
                ret.Add(i.ToString());
            }
        }

        return ret;
    }
}