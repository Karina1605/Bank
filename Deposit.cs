using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Deposit :Account
    {
        public decimal Percent
        {
            get;
            set;
        }

        public override void MonthlyOperation()
        {
            Operation operation = new Operation("Top up", CurrentBalance * Percent, this.Id);
            Operations.Add(operation);
        }
        public Deposit(decimal startCapital =0, string name ="", decimal percent=0):base(startCapital, name)
        {
            if (Percent < 0)
                throw new Exceptions.NegativeMonthlySum();
            Percent = percent* (decimal)0.01;
        }
        public Deposit() :base()
        {
            Percent = 0;
        }
        public override string ToString()
        {
            return "Deposit";
        }
        public override string GetCsvRow()
        {
            return base.GetCsvRow()+$";{Percent}";
        }
        public override string CreateHeader()
        {
            return base.CreateHeader() + ";\n Percent: " + Percent;
        }
    }
}
