#if DEBUG
namespace Weekly_487_Q3;
#endif

public class RideSharingSystem
{
    Queue<int> riders = [];
    Queue<int> drivers = [];
    HashSet<int> active = [];
    public RideSharingSystem()
    {

    }

    public void AddRider(int riderId)
    {
        riders.Enqueue(riderId);
        active.Add(riderId);
    }

    public void AddDriver(int driverId)
    {
        drivers.Enqueue(driverId);
    }

    public int[] MatchDriverWithRider()
    {
        // clean
        while (riders.Count > 0 && !active.Contains(riders.Peek()))
        {
            riders.Dequeue();
        }
        if (drivers.Count > 0 && riders.Count > 0)
        {
            return [drivers.Dequeue(), riders.Dequeue()];
        }
        return [-1, -1];
    }

    public void CancelRider(int riderId)
    {
        active.Remove(riderId);
    }
}

/**
 * Your RideSharingSystem object will be instantiated and called as such:
 * RideSharingSystem obj = new RideSharingSystem();
 * obj.AddRider(riderId);
 * obj.AddDriver(driverId);
 * int[] param_3 = obj.MatchDriverWithRider();
 * obj.CancelRider(riderId);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        RideSharingSystem rideSharingSystem = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "RideSharingSystem":
                    rideSharingSystem = new RideSharingSystem();
                    result.Add(null);
                    break;
                case "addRider":
                    rideSharingSystem.AddRider(values[i][0]);
                    result.Add(null);
                    break;
                case "addDriver":
                    rideSharingSystem.AddDriver(values[i][0]);
                    result.Add(null);
                    break;
                case "matchDriverWithRider":
                    result.Add(rideSharingSystem.MatchDriverWithRider());
                    break;
                case "cancelRider":
                    rideSharingSystem.CancelRider(values[i][0]);
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}