using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    class MoneyOperationException :Exception
    {
        public MoneyOperationException(string message = "Incorrect money operation") : base(message) { }
    }
    class NegativeStartBalance : MoneyOperationException
    {
        public NegativeStartBalance(string message ="Start balance can't be negative") :base(message){ }
    }
    class TooMuchSumForTaking : MoneyOperationException
    {
        public TooMuchSumForTaking(string message ="This sum too much for getting") : base(message) { }
    }
    class NegativeSum:MoneyOperationException
    {
        public NegativeSum(string message = "You can't apply negative number") : base(message) { }
    }
    class NegativeMonthlySum :MoneyOperationException
    {
        public NegativeMonthlySum(string message ="Attribute can't be negative") : base(message) { }
    }
    class EmptyAccountName:Exception
    {
        public EmptyAccountName(string message = "Name of account can't be empty"): base(message) { }

    }
}
