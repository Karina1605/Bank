using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class CreditCard : Account
    {
        
        public decimal Percent
        {
            get;
            set;
        }
        public decimal Limit
        {
            get;
            set;
        }

        public override void MonthlyOperation()
        {
            decimal p = CurrentBalance < 0 ? CurrentBalance * Percent : 0;
            Operation operation = new Operation("Top up", p, this.Id);
            Operations.Add(operation);
        }
        public override void TakeSum(decimal sum)
        {
            if (CurrentBalance<0 && Math.Abs(CurrentBalance - sum) > Limit)
                throw new Exception();
            else
            {
                Operation operation = new Operation("Withdrawal", -sum, this.Id);
                Operations.Add(operation);
            }
        }
        public CreditCard(decimal startCapital, string name, decimal percent, decimal limit):base(startCapital, name)
        {
            Percent = percent*(decimal)0.01;
            Limit = limit;
        }
        public CreditCard() : base()
        {
            Percent = 0;
            Limit = 0;
        }
        public override string GetCsvRow()
        {
            return base.GetCsvRow() +$";{Percent};{Limit}";
        }
        public override string ToString()
        {
            return "Credit card";
        }
        public override string CreateHeader()
        {
            return base.CreateHeader()+";\n Credit percent: "+Percent+" Limit: "+Limit;
        }
    }
}
