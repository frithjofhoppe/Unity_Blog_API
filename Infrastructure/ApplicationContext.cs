using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Business.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<BlogSpace> BlogSpaces { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ApplicationContext() : base("name=defaultConnectionString") { }
    }
}
