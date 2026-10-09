using EDA.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDA.Services
{
    public class AnalysticsService
    {
        private double _totalDeposited= 0;
        private double _totalWithdrawn= 0;
        public AnalysticsService(EventBus _bus)
        {
            _bus.Subscribe<Events.MoneyDeposittedEvent>(handleDeposit);
            _bus.Subscribe<Events.MoneyWithdrawnEvent>(handleWithdrawn);
        }

        private void handleDeposit(MoneyDeposittedEvent @event)
        {
            _totalDeposited += @event.amount;
            Console.WriteLine($"{DateTime.Now}[AnalyticsService]"+
                $"total Deposit: {_totalDeposited}");
        }
        private void handleWithdrawn(MoneyWithdrawnEvent @event) 
        {
            _totalWithdrawn += @event.amount;
            Console.WriteLine($"{DateTime.Now}[AnalyticsService]" +
                $"total Withdrawn: {_totalWithdrawn}");

        }
    }
}
