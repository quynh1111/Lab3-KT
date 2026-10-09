using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDA.Events
{
    public record MoneyDeposittedEvent(string accountId, double amount) : IEvent;
}
