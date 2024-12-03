namespace Problem_739;

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Stack<int[]> stack = [];
        for (int i = temperatures.Length - 1; i >= 0; i--)
        {
            int temp = temperatures[i];
            while (stack.Count > 0 && stack.Peek()[0] <= temp)
            {
                stack.Pop();
            }

            result[i] = stack.Count == 0 ? 0 : stack.Peek()[1] - i;
            stack.Push([temp, i]);
        }

        return result;
    }
}