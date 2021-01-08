using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank
{
    public class Operation
    {
        private static int idGenerator = 1000;
        public int Id { get; set; }
        
        public virtual int AccountId { get; set; }
        public string NameOfOperation
        {
            get;
            set;
        }
        public decimal SumOfOperation
        {
            get;
            set;
        }
        public DateTime DateOfOperation
        {
            get;
            set;
        }
        
        public Operation(string description, decimal sum, int account)
        {
            NameOfOperation = description;
            SumOfOperation = sum;
            DateOfOperation = DateTime.Now;
            AccountId = account;
           // Id = ++idGenerator;
        }
        public Operation()
        {

        }
        
    }
}
