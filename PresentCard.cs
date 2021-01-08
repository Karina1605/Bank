using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class PresentCard : Account
    {
        public decimal MonthlySum
        {
            get;
            set;
        }
        public override void MonthlyOperation()
        {
            Operation operation = new Operation("Top up", MonthlySum, this.Id);
            Operations.Add(operation);
        }
        public PresentCard(decimal startCapital, string name, decimal monthSum) : base(startCapital, name)
        {
            if (MonthlySum < 0)
                throw new Exceptions.NegativeMonthlySum();
            MonthlySum = monthSum;
        }
        public PresentCard() : base()
        {
            MonthlySum = 0;
        }
        public override string ToString()
        {
            return "Present card";
        }
        public override string GetCsvRow()
        {
            return base.GetCsvRow()+$";{MonthlySum}";
        }
        public override string CreateHeader()
        {
            return base.CreateHeader()+";\n Monthly sum: "+MonthlySum;
        }
    }
}
