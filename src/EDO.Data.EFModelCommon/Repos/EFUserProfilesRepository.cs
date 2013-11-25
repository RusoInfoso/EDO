using EDO.Model.Common.Abstract;
using EDO.Model.Common.Abstract.Repositories;
using EDO.Model.Common.Entities;
using System.Data.Entity;
using System.Linq;

namespace EDO.Data.EFModelCommon.Repos
{
    public class EFUserProfilesRepository : EFGenericRepository<UserProfile>, IUserProfilesRepository
    {
        public EFUserProfilesRepository(DbContext context) : base(context)
        {
        }
    }
}
