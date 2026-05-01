public class Bank
{
    private readonly long[] accounts;

    public Bank(long[] balance)
    {
        int n = balance.Length;
        accounts = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            accounts[i] = balance[i - 1];
        }
    }

    public bool Transfer(int account1, int account2, long money)
    {
        if (!IsValid(account1) || !IsValid(account2)) return false;
        if (accounts[account1] < money) return false;
        accounts[account1] -= money;
        accounts[account2] += money;
        return true;
    }

    public bool Deposit(int account, long money)
    {
        if (!IsValid(account)) return false;
        accounts[account] += money;
        return true;
    }

    public bool Withdraw(int account, long money)
    {
        if (!IsValid(account)) return false;
        if (accounts[account] < money) return false;
        accounts[account] -= money;
        return true;
    }

    bool IsValid(int account) => account > 0 && account <= accounts.Length;
}

/**
 * Your Bank object will be instantiated and called as such:
 * Bank obj = new Bank(balance);
 * bool param_1 = obj.Transfer(account1,account2,money);
 * bool param_2 = obj.Deposit(account,money);
 * bool param_3 = obj.Withdraw(account,money);
 */


#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        Bank bank = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Bank":
                    bank = new Bank(CastType<long[][]>(values[i])[0]);
                    result.Add(null);
                    break;
                case "withdraw":
                    long[] withdrawArgs = CastType<long[]>(values[i]);
                    result.Add(bank.Withdraw((int)withdrawArgs[0], withdrawArgs[1]));
                    break;
                case "transfer":
                    long[] transferArgs = CastType<long[]>(values[i]);
                    result.Add(bank.Transfer((int)transferArgs[0], (int)transferArgs[1], transferArgs[2]));
                    break;
                case "deposit":
                    long[] depositArgs = CastType<long[]>(values[i]);
                    result.Add(bank.Deposit((int)depositArgs[0], depositArgs[1]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
