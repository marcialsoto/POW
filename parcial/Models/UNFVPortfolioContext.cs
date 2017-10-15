using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class UNFVPortfolioContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UNFVPortfolioContext() : base("name=UNFVPortfolioContext")
        {
        }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Employment> Jobs { get; set; }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Enterprise> Clients { get; set; }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Degree> Degrees { get; set; }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Skill> Skills { get; set; }

        public System.Data.Entity.DbSet<UNFV.Portfolio.Models.Education> Educations { get; set; }
    }
}
