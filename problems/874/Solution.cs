public class Solution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        var obstacleMap = new Dictionary<(int, int), bool>();
        foreach (var obstacle in obstacles)
        {
            obstacleMap[(obstacle[0], obstacle[1])] = true;
        }
        var maxDistance = 0;
        int x = 0, y = 0;  // initial position of the robot
        int directionIndex = 0;  // starting direction (North)

        foreach (var command in commands)
        {
            if (command == -1)
            {
                directionIndex = (directionIndex + 1) % 4;
            }
            else if (command == -2)
            {
                directionIndex = (directionIndex + 3) % 4; // plus 3 instead of sub 1
            }
            else
            {
                for (var i = 0; i < command; i++)
                {
                    var nextX = x + directions[directionIndex, 0];
                    var nextY = y + directions[directionIndex, 1];

                    if (!obstacleMap.ContainsKey((nextX, nextY)))
                    {
                        x = nextX;
                        y = nextY;
                        maxDistance = Math.Max(maxDistance, x * x + y * y);
                    }
                    else
                    {
                        break;  // stop moving in this direction if an obstacle is encountered
                    }
                }
            }
        }

        return maxDistance;
    }
}