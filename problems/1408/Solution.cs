#if DEBUG
namespace Problems_1408;
#endif

public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        IList<string> result = [];
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j) continue;
                if (words[j].Contains(words[i]))
                {
                    result.Add(words[i]);
                    break;
                }
            }
        }
        return result;
    }
}