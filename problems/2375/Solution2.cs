#if DEBUG
namespace Problems_2375_2;
#endif

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        StringBuilder sb = new();

        BuildSequence(0, 0, pattern.ToCharArray(), sb);
        char[] ans = sb.ToString().ToCharArray();
        Array.Reverse(ans);
        return new string(ans);
    }

    private int BuildSequence(int currIdx, int currVal, char[] pattern, StringBuilder sb)
    {
        if (currIdx != pattern.Length)
        {
            if (pattern[currIdx] == 'I') BuildSequence(currIdx + 1, currIdx + 1, pattern, sb);
            else currVal = BuildSequence(currIdx + 1, currVal, pattern, sb);
        }
        sb.Append(currVal + 1);
        return currVal + 1;
    }
}