public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        // has 4 valid form
        // form1: all zero
        // form2: all one
        // form3: 0..010...
        // form4: 100.001

        int ones = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1') ones++;
        }
        int zeros = n - ones;
        int ans = n;
        ans = Math.Min(ans, ones);
        ans = Math.Min(ans, zeros);
        ans = Math.Min(ans, Math.Max(0, ones - 1));

        if (n >= 2)
        {
            int firstOne = s[0] == '1' ? 1 : 0;
            int lastOne = s[^1] == '1' ? 1 : 0;
            int midOnes = ones - firstOne - lastOne;

            ans = Math.Min(ans, 1 - firstOne + 1 - lastOne + midOnes);
        }

        return ans;
    }
}
