public class Solution
{
    const int DRAW = 0;
    const int MOUSE = 1;
    const int CAT = 2;

    public int CatMouseGame(int[][] graph)
    {
        int n = graph.Length;
        // color[mouse, cat, turn]
        // 0: draw/ unknow
        // 1: mouse win
        // 2: cat win
        int[,,] color = new int[n, n, 2];
        // degree[mouse, cat, turn]
        // number of available moves
        int[,,] degree = new int[n, n, 2];
        for (int m = 0; m < n; m++)
        {
            for (int c = 0; c < n; c++)
            {
                // mouse turn
                degree[m, c, 0] = graph[m].Length;
                // cat turn
                int moves = 0;
                foreach (int x in graph[c])
                {
                    if (x == 0) continue;
                    moves++;
                }
                degree[m, c, 1] = moves;
            }
        }
        Queue<int[]> q = [];
        // [mouse, cat, turn, return]
        // initial mouse win
        for (int c = 1; c < n; c++)
        {
            for (int t = 0; t < 2; t++)
            {
                color[0, c, t] = MOUSE;
                q.Enqueue([0, c, t, MOUSE]);
            }
        }
        // initial cat win
        for (int i = 1; i < n; i++)
        {
            for (int t = 0; t < 2; t++)
            {
                color[i, i, t] = CAT;
                q.Enqueue([i, i, t, CAT]);
            }
        }
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            int mouse = cur[0];
            int cat = cur[1];
            int turn = cur[2];
            int res = cur[3];
            foreach (var parent in Parents(graph, mouse, cat, turn))
            {
                int pm = parent[0];
                int pc = parent[1];
                int pt = parent[2];
                if (color[pm, pc, pt] != DRAW) continue;
                bool canWin = (pt == 0 && res == MOUSE) || (pt == 1 && res == CAT);
                if (canWin)
                {
                    color[pm, pc, pt] = res;
                    q.Enqueue([pm, pc, pt, res]);
                }
                else
                {
                    degree[pm, pc, pt]--;
                    if (degree[pm, pc, pt] == 0)
                    {
                        int loseResult = (pt == 0) ? CAT : MOUSE;
                        color[pm, pc, pt] = loseResult;
                        q.Enqueue([pm, pc, pt, loseResult]);
                    }
                }
            }
        }
        return color[1, 2, 0];
    }

    List<int[]> Parents(int[][] graph, int mouse, int cat, int turn)
    {
        List<int[]> parents = [];
        if (turn == 0)
        {
            foreach (int prevCat in graph[cat])
            {
                if (prevCat == 0) continue;
                parents.Add([mouse, prevCat, 1]);
            }
        }
        else
        {
            foreach (int prevMouse in graph[mouse])
            {
                parents.Add([prevMouse, cat, 0]);
            }
        }
        return parents;
    }
}
