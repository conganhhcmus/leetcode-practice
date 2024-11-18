namespace Problem_1652;

public class Solution
{
    public static void Execute()
    {
        int[] code = [2, 4, 9, 3];
        int k = -2;
        var solution = new Solution();
        var result = solution.Decrypt(code, k);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
    public int[] Decrypt(int[] code, int k)
    {
        if (k == 0)
        {
            Array.Fill(code, 0);
            return code;
        }

        int curSum = 0;
        int start = 1;
        if (k < 0)
        {
            k *= -1;
            start = code.Length - k;
        }

        int end = (start - 1) % code.Length;

        for (int i = 0; i < k; i++)
        {
            end = (end + 1) % code.Length;
            curSum += code[end];
        }

        int[] ans = new int[code.Length];
        for (int i = 0; i < code.Length; i++)
        {
            ans[i] = curSum;
            curSum -= code[start];
            start = (start + 1) % code.Length;
            end = (end + 1) % code.Length;
            curSum += code[end];
        }
        return ans;
    }
}