using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Bank.models
{
    class BankDbContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<PresentCard> PresentCards { get; set; }
        public DbSet<Operation> Operarions { get; set; }
        public BankDbContext() : base("name=BankContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().HasKey(i => i.Id);
        }
        static BankDbContext()
        {
            Database.SetInitializer(new BankDbInitializer());
            
        }
    }
}
