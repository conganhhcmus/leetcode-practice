#if DEBUG
namespace Problems_3307;
#endif

public class Solution
{
    public char KthCharacter(long k, int[] op)
    {
        int ans = 0;
        while (k != 1)
        {
            int skip = (int)Math.Log2(k);
            if ((1L << skip) == k) skip--;
            if (op[skip] == 1)
            {
                ans++;
            }
            else
            {
                // don't do anything
            }
            k -= 1L << skip;
        }

        ans %= 26;
        return (char)(ans + 'a');
    }
}

/*
    k = 10, operations = [0,1,0,1]

    _: "a"
    1: "aa"
    2: "aabb"
    3: "aabbaabb"
    4: "a[a]bbaabbb[b]ccbbcc"

*/