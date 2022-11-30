using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.ContextLibrary
{
    public class MyCVContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;database=MyCVDB;trusted_connection=true;");
        }

        public DbSet<About> Abouts{ get; set; }
        public DbSet<ClmOneExperince> ClmOneExperinces { get; set; }
        public DbSet<ClmTwoExperince> ClmTwoExperinces { get; set; }
        public DbSet<ClmOneSkill> ClmOneSkills { get; set; }
        public DbSet<ClmTwoSkill> ClmTwoSkills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
