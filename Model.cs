using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.models;
namespace Bank
{
    class Model :IDisposable
    {
        models.BankDbContext BankDb;
        public Dictionary<int, List<Account>> Accounts { get; private set; }
        public void AddAccount(Account account)
        {
            if (account is Deposit)
                BankDb.Deposits.Add((Deposit)account);
            else
                if (account is CreditCard)
                BankDb.CreditCards.Add((CreditCard)account);
            else
                if (account is PresentCard)
                BankDb.PresentCards.Add((PresentCard)account);
        }
        public void UpdateAccount(Account account, int count)
        {
            for (int i=account.Operations.Count-count; i<account.Operations.Count; ++i)
                BankDb.Operarions.Add(account.Operations.ElementAt(i));
            //BankDb.Accounts.Add(account);
            //var dbacc = (from z in BankDb.Accounts where z.Id == account.Id select z).First();

        }
        public void Save()
        {
            BankDb.SaveChanges();
        }
        public Account GetAccount(int Id)
        {
            var r1 = BankDb.Accounts.Include("Operations").ToList();
            var res = (from b in r1 where b.Id == Id select b).ToArray();
            if (res.Length != 0)
            {
                
                return res[0];
            }
                
            return null;
        }
        public List<Account> GetCommonTable()
        {
            return BankDb.Accounts.Include("Operations").ToList();
        }
        public List<Deposit> GetDeposits()
        {
            return BankDb.Deposits.Include("Operations").ToList();
        }
        public List<CreditCard> GetCreditCards()
        {
            return BankDb.CreditCards.Include("Operations").ToList();
        }
        public List<PresentCard> GetPresentCards()
        {
            return BankDb.PresentCards.Include("Operations").ToList();
        }

        public void Dispose()
        {
            ((IDisposable)BankDb).Dispose();
        }

        public Model()
        {
            BankDb = new models.BankDbContext();
        }
    }
}
