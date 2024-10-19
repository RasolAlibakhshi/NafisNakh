using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class ContextFactory:IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<Context>();
            OptionBuilder.UseSqlServer("Data Source=RASOL-PC\\MYSQLSERVER;Initial Catalog=NafisNakhProject1;TrustServerCertificate=True;Persist Security Info=False;User ID=sa;Password=4225279r;MultipleActiveResultSets=True;");
            return new Context(OptionBuilder.Options);
        }
    }
}
