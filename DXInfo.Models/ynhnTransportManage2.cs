using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DXInfo.Models
{
    public partial class ynhnTransportManage
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnet_Role>().ToTable("aspnet_Roles");
            modelBuilder.Entity<aspnet_Sitemap>().ToTable("aspnet_Sitemaps");
            modelBuilder.Entity<aspnet_AuthorizationRule>().ToTable("aspnet_AuthorizationRules");
            modelBuilder.Entity<aspnet_User>().ToTable("aspnet_Users");
            modelBuilder.Entity<aspnet_UsersInRole>().ToTable("aspnet_UsersInRoles");
            modelBuilder.Entity<NameCode>().ToTable("NameCode");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<TransportsLog>().ToTable("TransportsLog");
            modelBuilder.Entity<ekey>().ToTable("ekey");
            base.OnModelCreating(modelBuilder);
        }
    }
}
