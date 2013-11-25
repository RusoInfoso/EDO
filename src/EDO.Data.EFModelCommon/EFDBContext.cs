using System.Data.Entity;
using EDO.Model.Common.Entities;
using System.Linq;
using System;
using System.Configuration;
using EDO.Data.EFModelCommon.Configuration;

namespace EDO.Data.EFModelCommon
{
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base(nameOrConnectionString: EFDBContext.ConnectionString) { }
        static EFDBContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        /*
         * Наши таблички
         */
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
        /** --- **/
              

        public static string ConnectionString
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // При сохранении изменений любых проверяем наличие автоматических полей и 
        // обновляем их        
        public override int SaveChanges()
        {
            ApplyRules();

            return base.SaveChanges();
        }
                
        private void ApplyRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                        .Where(
                                 e => e.Entity is Model.Common.Entities.Entity &&
                                 (
                                    (e.State == EntityState.Added) || (e.State == EntityState.Modified)
                                 )
                              )
                    )
            {
                Model.Common.Entities.Entity e = (Model.Common.Entities.Entity)entry.Entity;

                // Второе условие На случай seed из Миграции - пока не придумал как по другому обойти
                if (entry.State == EntityState.Added || e.Created == DateTime.MinValue || e.Created == null)
                {
                    e.Created = DateTime.Now;
                }

                e.Modified = DateTime.Now;
            }
        }
    }
}
