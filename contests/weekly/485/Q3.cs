public class AuctionSystem
{
    Dictionary<int, PriorityQueue<int, (int p, int v)>> dict;
    Dictionary<(int, int), int> map;
    public AuctionSystem()
    {
        dict = [];
        map = [];
    }

    public void AddBid(int userId, int itemId, int bidAmount)
    {
        if (!dict.ContainsKey(itemId)) dict[itemId] = new(
        Comparer<(int p, int v)>.Create((a, b) =>
        {
            int cmp = b.p.CompareTo(a.p);
            if (cmp != 0) return cmp;
            return b.v.CompareTo(a.v);
        }));
        dict[itemId].Enqueue(userId, (bidAmount, userId));
        map[(userId, itemId)] = bidAmount;
    }

    public void UpdateBid(int userId, int itemId, int newAmount)
    {
        AddBid(userId, itemId, newAmount);
    }

    public void RemoveBid(int userId, int itemId)
    {
        map[(userId, itemId)] = -1;
    }

    public int GetHighestBidder(int itemId)
    {
        if (!dict.ContainsKey(itemId)) return -1;
        var pq = dict[itemId];
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int userId, out var kp);
            if (map[(userId, itemId)] == kp.p)
            {
                pq.Enqueue(userId, kp);
                return userId;
            }
        }
        return -1;
    }
}

/**
 * Your AuctionSystem object will be instantiated and called as such:
 * AuctionSystem obj = new AuctionSystem();
 * obj.AddBid(userId,itemId,bidAmount);
 * obj.UpdateBid(userId,itemId,newAmount);
 * obj.RemoveBid(userId,itemId);
 * int param_4 = obj.GetHighestBidder(itemId);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        AuctionSystem auctionSystem = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "AuctionSystem":
                    auctionSystem = new AuctionSystem();
                    result.Add(null);
                    break;
                case "addBid":
                    auctionSystem.AddBid(values[i][0], values[i][1], values[i][2]);
                    result.Add(null);
                    break;
                case "updateBid":
                    auctionSystem.UpdateBid(values[i][0], values[i][1], values[i][2]);
                    result.Add(null);
                    break;
                case "removeBid":
                    auctionSystem.RemoveBid(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
                case "getHighestBidder":
                    result.Add(auctionSystem.GetHighestBidder(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}
