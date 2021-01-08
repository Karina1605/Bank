using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bank.models
{
    class BankDbInitializer :DropCreateDatabaseIfModelChanges<BankDbContext>
    {
        protected override void Seed(BankDbContext context)
        {
            base.Seed(context);
        }
    }
}
