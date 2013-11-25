using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.Data.EFModelCommon.Configuration
{
    public class CustomDatabaseInitializer : CreateDatabaseIfNotExists<EFDBContext>
    {
        protected override void Seed(EFDBContext context)
        {
            base.Seed(context);
        }
    }
}
