namespace EDO.Data.EFModelCommon.Migrations
{
    using EDO.Model.Common.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EDO.Data.EFModelCommon.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EDO.Data.EFModelCommon.EFDBContext context)
        {
            SeedAccountTypes(context);
            SeedBusiness(context);
        }

        private void SeedBusiness(EDO.Data.EFModelCommon.EFDBContext context)
        {
            List<Business> businessList = new List<Business>();


            businessList.ForEach(
                s => context.Businesses.AddOrUpdate(p => p.Title, s)
            );

            context.SaveChanges();
        }

        private void SeedAccountTypes(EDO.Data.EFModelCommon.EFDBContext context)
        {
            List<AccountType> types = new List<AccountType>();

            types.Add(new AccountType
            {
                Title = "Индивидуальный предпрениматель",
                Description = "Индивидуальный предприниматель",
                Code = "individual"
            });

            types.Add(new AccountType
            {
                Title = "Организация",
                Description = "Организация",
                Code = "business"
            });

            types.Add(new AccountType
            {
                Title = "Физическое лицо",
                Description = "Физическое лицо",
                Code = "private"
            });

            types.ForEach(
                s => context.AccountTypes.AddOrUpdate(p => p.Code, s)
            );

            context.SaveChanges();
        }
    }
}
