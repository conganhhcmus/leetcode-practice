public class Robot
{
    int n, m, x, y, st, round;
    int[][] dirs = [[0, 1], [1, 0], [0, -1], [-1, 0]];

    public Robot(int width, int height)
    {
        n = width;
        m = height;
        x = 0;
        y = 0;
        st = 1;
        round = 2 * (n + m) - 4; // remove 4 duplicate [0,0], [0,n], [0,m], [n,m]
        // 0 : North, 1: East, 2: South, 3: West
    }

    public void Step(int num)
    {
        while (num > 0)
        {
            num -= ((num - 1) / round) * round;

            // k * dirs[st][0] + x = n
            // k * dirs[st][1] + y = m
            int k = 0;
            if (st == 0)
            {
                k = m - y - 1;
            }
            else if (st == 1)
            {
                k = n - x - 1;
            }
            else if (st == 2)
            {
                k = y;
            }
            else
            {
                k = x;
            }
            if (k == 0)
            {
                st = (st - 1 + 4) % 4;
            }
            else
            {
                k = Math.Min(k, num);
                num -= k;
                x += k * dirs[st][0];
                y += k * dirs[st][1];
            }
        }
    }

    public int[] GetPos()
    {
        return [x, y];
    }

    public string GetDir()
    {
        if (st == 0) return "North";
        if (st == 1) return "East";
        if (st == 2) return "South";
        return "West";
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.Step(num);
 * int[] param_2 = obj.GetPos();
 * string param_3 = obj.GetDir();
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        Robot robot = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Robot":
                    robot = new Robot(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
                case "step":
                    robot.Step(values[i][0]);
                    result.Add(null);
                    break;
                case "getPos":
                    result.Add(robot.GetPos());
                    break;
                case "getDir":
                    result.Add(robot.GetDir());
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}