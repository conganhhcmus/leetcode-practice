#if DEBUG
namespace Biweekly_152_Q2;
#endif

public class Spreadsheet
{
    public int[,] Sheet;
    public Spreadsheet(int rows)
    {
        Sheet = new int[rows + 1, 26];
    }

    public void SetCell(string cell, int value)
    {
        int col = cell[0] - 'A';
        int row = int.Parse(cell[1..]);
        Sheet[row, col] = value;
    }

    public void ResetCell(string cell)
    {
        int col = cell[0] - 'A';
        int row = int.Parse(cell[1..]);
        Sheet[row, col] = 0;
    }

    public int GetValue(string formula)
    {
        string[] vals = formula[1..].Split('+');
        int result = 0;
        foreach (string v in vals)
        {
            if (HasAllDigit(v)) result += int.Parse(v);
            else
            {
                int col = v[0] - 'A';
                int row = int.Parse(v[1..]);
                result += Sheet[row, col];
            }
        }
        return result;
    }

    bool HasAllDigit(string val)
    {
        foreach (char c in val)
        {
            if (!char.IsDigit(c)) return false;
        }
        return true;
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, string[][] values)
    {
        List<dynamic> result = [];
        Spreadsheet spreadsheet = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Spreadsheet":
                    spreadsheet = new Spreadsheet(int.Parse(values[i][0]));
                    result.Add(null);
                    break;
                case "getValue":
                    result.Add(spreadsheet.GetValue(values[i][0]));
                    break;
                case "setCell":
                    spreadsheet.SetCell(values[i][0], int.Parse(values[i][1]));
                    result.Add(null);
                    break;
                case "resetCell":
                    spreadsheet.ResetCell(values[i][0]);
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}