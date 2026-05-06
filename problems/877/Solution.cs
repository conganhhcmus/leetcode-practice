public class Solution
{
    public bool StoneGame(int[] piles)
    {
        // indices = [0, 1, 2, ..., n]
        // left = 0, right = n (n is odd)
        // Alice calc:
        // sumEven = piles[0] + piles[2] + ...
        // sumOdd = piles[1] + piles[3] + ... + piles[n]
        // if (sumEven > sumOdd) Alice chooses even, alway pick even indices (0, 2, 4, ...)
        // else Alice chooses odd, pick odd indices (1, 3, 5, ..., n)
        return true;
    }
}
