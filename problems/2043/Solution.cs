#if DEBUG
namespace Problems_2043;
#endif

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



public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);

        List<dynamic> result = [];
        Bank bank = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Bank":
                    bank = new Bank(CastType<long[]>(objectList[i])[0]);
                    result.Add(null);
                    break;
                case "withdraw":
                    result.Add(bank.Withdraw(CastType<int>(objectList[i])[0], CastType<long>(objectList[i])[1]));
                    break;
                case "transfer":
                    result.Add(bank.Transfer(CastType<int>(objectList[i])[0], CastType<int>(objectList[i])[1], CastType<long>(objectList[i])[2]));
                    break;
                case "deposit":
                    result.Add(bank.Deposit(CastType<int>(objectList[i])[0], CastType<long>(objectList[i])[1]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T[] CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value));
    }
}