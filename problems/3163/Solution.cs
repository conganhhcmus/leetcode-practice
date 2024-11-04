using System.Text;

namespace Problem_3163;

public class Solution
{
    public static void Execute()
    {
        string word = "aaaaaaaaaaaaaabb";
        var solution = new Solution();
        Console.WriteLine(solution.CompressedString(word));
    }
    public string CompressedString(string word)
    {
        word += "-";
        StringBuilder comp = new();
        int curr = 0;
        int count = 0;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == word[curr])
            {
                count++;
                if (count > 9)
                {
                    comp.Append("9" + word[curr]);
                    count = 1;
                }
            }
            else
            {
                comp.Append(count.ToString() + word[curr]);
                curr = i;
                count = 1;
            }
        }

        return comp.ToString();
    }
}