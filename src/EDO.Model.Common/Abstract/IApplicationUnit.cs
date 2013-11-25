using EDO.Model.Common.Abstract.Repositories;
using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.Model.Common.Abstract
{
    public interface IApplicationUnit : IDisposable
    {
        IGenericRepository<UserProfile> UserProfiles { get; }
        IGenericRepository<Business> Businesses { get; }
        IGenericRepository<Office> Offices { get; }
        IGenericRepository<Address> Addresses { get; }
        IGenericRepository<UserPosition> UserPositions { get; }
        IGenericRepository<AccountType> AccountTypes { get; }

        void SaveChanges();
    }
}
