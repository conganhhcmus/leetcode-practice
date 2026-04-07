public class Robot
{
    int w, h, mod, step;
    int[][] pos;
    string[] dirs;

    public Robot(int width, int height)
    {
        w = width - 1;
        h = height - 1;
        mod = 2 * (w + h);
        pos = new int[mod][];
        dirs = new string[mod];

        pos[0] = [0, 0];
        dirs[0] = "South";

        int k = 1;
        for (int i = 1; i <= w; i++)
        {
            pos[k] = [i, 0];
            dirs[k] = "East";
            k++;
        }
        for (int i = 1; i <= h; i++)
        {
            pos[k] = [w, i];
            dirs[k] = "North";
            k++;
        }
        for (int i = 1; i <= w; i++)
        {
            pos[k] = [w - i, h];
            dirs[k] = "West";
            k++;
        }
        for (int i = 1; i < h; i++)
        {
            pos[k] = [0, h - i];
            dirs[k] = "South";
            k++;
        }
    }

    public void Step(int num)
    {
        step += num;
    }

    public int[] GetPos()
    {
        return pos[step % mod];
    }

    public string GetDir()
    {
        if (step == 0) return "East";
        return dirs[step % mod];
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