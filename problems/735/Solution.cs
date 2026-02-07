public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new();

        foreach (int asteroid in asteroids)
        {
            bool isExplode = false;

            while (stack.Count > 0 && stack.Peek() > 0 && asteroid < 0)
            {
                if (Math.Abs(stack.Peek()) > Math.Abs(asteroid))
                {
                    isExplode = true;
                    break;
                }
                else if (Math.Abs(stack.Peek()) == Math.Abs(asteroid))
                {
                    stack.Pop();
                    isExplode = true;
                    break;
                }
                else
                {
                    stack.Pop();
                }
            }

            if (!isExplode)
            {
                stack.Push(asteroid);
            }
        }

        return stack.Reverse().ToArray();
    }
}