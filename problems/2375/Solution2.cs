#if DEBUG
namespace Problems_2375_2;
#endif

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        char[] numbers = new char[pattern.Length + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = (char)(i + '1');
        }
        BackTracking(pattern, numbers, 0);
        return new string(numbers);
    }

    private bool BackTracking(string pattern, char[] numbers, int start)
    {
        if (Check(pattern, new string(numbers))) return true;

        for (int i = start; i < numbers.Length; i++)
        {
            (numbers[start], numbers[i]) = (numbers[i], numbers[start]);
            if (BackTracking(pattern, numbers, start + 1)) return true;
            (numbers[start], numbers[i]) = (numbers[i], numbers[start]);
        }

        return false;
    }

    private bool Check(string pattern, string sequence)
    {
        int n = pattern.Length;
        if (sequence.Length != n + 1) return false;
        for (int i = 0; i < n; i++)
        {
            if (pattern[i] == 'I' && sequence[i] >= sequence[i + 1]) return false;
            if (pattern[i] == 'D' && sequence[i] <= sequence[i + 1]) return false;
        }
        return true;
    }
}