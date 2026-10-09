// See https://aka.ms/new-console-template for more information
using EDA;
using EDA.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        EventBus bus = new EventBus();//evet channel
        var accountService = new AccountService(bus);
        var analyticsService = new AnalysticsService(bus);

        accountService.CreateAccount("TVD", "John Doe");
        accountService.DepositMoney("TVD", 80000);
        accountService.WithdrawMoney("TVD", 10000);
    }
}
