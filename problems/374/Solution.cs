namespace Problem_374;

public class GuessGame
{
    protected int pickNumber;
    protected int guess(int num)
    {
        if (num < pickNumber) return 1;
        if (num > pickNumber) return -1;
        return 0;
    }
}

public class Solution : GuessGame
{
    public int Execute(int n, int k)
    {
        var solution = new Solution
        {
            pickNumber = k
        };
        return solution.GuessNumber(n);
    }
    public int GuessNumber(int n)
    {
        if (guess(1) == 0) return 1;
        if (guess(n) == 0) return n;
        int min = 1;
        int max = n;
        int guessNumber = min + ((max - min) / 2);
        while (min <= max)
        {
            var val = guess(guessNumber);
            if (val == 0)
            {
                break;
            }
            else if (val > 0)
            {
                min = guessNumber + 1;
            }
            else
            {
                max = guessNumber - 1;
            }
            guessNumber = min + ((max - min) / 2);
        }

        return guessNumber;
    }
}