using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Access
{
    public class SqlServerDbContext : DomainDbContext
    {
        public SqlServerDbContext(IConfiguration configuration) : base(configuration)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration["ConnectionStrings:Mssql"]);
        }
    }
}
