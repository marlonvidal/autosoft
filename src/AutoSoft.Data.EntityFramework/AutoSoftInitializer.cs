using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework
{
    public class AutoSoftInitializer : DropCreateDatabaseIfModelChanges<AutoSoftContext>
    {
        protected override void Seed(AutoSoftContext context)
        {
            base.Seed(context);
        }
    }
}
