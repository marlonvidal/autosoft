using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework
{
    public class AutoSoftContext : DbContext
    {
        public AutoSoftContext()
            : base("AutoSoftConnectionString")
        {
            Database.SetInitializer(new AutoSoftInitializer());
        }
    }
}
