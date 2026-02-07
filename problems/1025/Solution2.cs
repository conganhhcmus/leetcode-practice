public class Solution
{
    public bool DivisorGame(int n)
    {
        // if n is even, you can win. So you can choose x = 1 to n-x is odd
        // if n is odd, you will lose. So you have to choose x is odd and n-x is even
        // n = 2 is win
        // n = 3 is lose
        return n % 2 == 0;
    }
}