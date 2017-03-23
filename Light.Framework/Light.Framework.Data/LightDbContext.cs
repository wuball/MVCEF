using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Text;
using Light.Framework.Core.Extensions;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Light.Framework.Core.Logging;
using Light.Framework.Data.Entities;

namespace Light.Framework.Data
{
    public class LightDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public LightDbContext() : base("LightDbContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LightDbContext, DbConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除关系
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //移除表名复数形式
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //配置实体和数据表的关系
            var mappings = GetType().Assembly.GetInheritedTypes(typeof(EntityTypeConfiguration<>));
            foreach (var mapping in mappings)
            {
                dynamic instance = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(instance);
            }
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LightDbContext"].ConnectionString;
        }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var item in error.ValidationErrors)
                    {
                        sb.AppendLine(item.PropertyName + ": " + item.ErrorMessage);
                    }
                }
                Logger.Error("SaveChanges.DbEntityValidation", ex.GetAllMessages() + sb);
                throw;
            }
        }
    }
}
