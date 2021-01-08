using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bank
{
    public abstract class Account
    {
        public int Id{ get; set; } 
        public DateTime opened { get; set;}
        public ICollection<Operation> Operations { get; set; }
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal CurrentBalance => (from o in Operations select o.SumOfOperation).Sum();
        
        public void AddSum(decimal sum)
        {
            if (sum < 0)
                throw new Exceptions.NegativeSum();
            Operation operation = new Operation("Top up", sum, this.Id);
            Operations.Add(operation);
        }
        public virtual void TakeSum(decimal sum)
        {
            if (sum < 0)
                throw new Exceptions.NegativeSum();
            if (CurrentBalance - sum < 0)
                throw new Exceptions.TooMuchSumForTaking();
            Operation operation = new Operation("Withdrawal", -sum, this.Id);
            Operations.Add(operation);
        }
        public abstract void MonthlyOperation();

        public Account(decimal startCapital, string Name)
        {
            if (startCapital < 0)
                throw new Exceptions.NegativeStartBalance();
            if (Name == "" || Name == null)
                throw new Exceptions.EmptyAccountName();
            Operations = new List<Operation>();
            this.Name = Name;
            Operations.Add(new Operation("Create", startCapital, this.Id));
            opened = Operations.First().DateOfOperation;
            
        }
        public Account()
        {
            Operations = new List<Operation>();
            Name = "";
        }
        public virtual string GetCsvRow()
        {
            string res = $"{Id};{opened};{Name};{CurrentBalance}";
            return res;
        }
        public virtual string CreateHeader()
        {
            string res = "Date: "+DateTime.Now.ToString("d")+"; Name: "+Name+";\n Type: "+ToString()+" Current balance: "+CurrentBalance;
            return res;
        }
    }
}
