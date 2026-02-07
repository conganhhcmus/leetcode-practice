public class Solution
{
    public string GetHint(string secret, string guess)
    {
        int bulls = 0;
        int n = secret.Length;
        int[] count = new int[10];
        for (int i = 0; i < n; i++)
        {
            if (secret[i] == guess[i]) bulls++;
            count[secret[i] - '0']++;
            count[guess[i] - '0']--;
        }
        int cows = n - bulls;
        for (int i = 0; i < 10; i++)
        {
            if (count[i] < 0) cows += count[i];
        }

        return $"{bulls}A{cows}B";
    }
}