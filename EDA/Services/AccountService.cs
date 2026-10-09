using EDA.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDA.Services
{
    public class AccountService
    {
        private readonly EventBus _bus;
        public readonly Dictionary<string, double> _accounts = new();
        public AccountService(EventBus eventbus)
        {
            _bus = eventbus;
        }
        public void CreateAccount(string accountId, string owner)
        {
            // Logic to create account
            _accounts[accountId] = 0; // Initialize account balance to 0

            Console.WriteLine($"{DateTime.Now} [AccountService]" + 
                $" Account created: {accountId}, Owner: {owner}");
            _bus.Publish(new AccountCreatedEvent(accountId, owner));

        }

        public void DepositMoney(string accountId, double amount)
        {
            // Logic to deposit money
            _accounts[accountId]+= amount; // Update account balance
            Console.WriteLine($"{DateTime.Now} [AccountService]" + 
                $" Money deposited: {amount} to Account: {accountId}");
            _bus.Publish(new MoneyDeposittedEvent(accountId, amount));
        }
        public void WithdrawMoney(string accountId, double amount)
        {
            // Logic to withdraw money
            if (_accounts[accountId]>= amount)
            {
                _accounts[accountId] -= amount; // Update account balance
                Console.WriteLine($"{DateTime.Now} [AccountService]" +
                    $" Money withdrawn: {amount} from Account: {accountId}");
                _bus.Publish(new MoneyWithdrawnEvent(accountId, amount));

            }
            else
            {
                Console.WriteLine(" Error: you cannot withdraw more than the available balance ");

            }
        }
    }
} 
