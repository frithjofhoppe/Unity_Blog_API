using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Business.Entity;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public ApplicationContext() : base("name=defaultConnectionString") { }
    }
}
