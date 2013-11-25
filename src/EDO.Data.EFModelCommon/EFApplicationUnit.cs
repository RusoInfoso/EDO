using EDO.Model.Common.Abstract;
using EDO.Model.Common.Abstract.Repositories;
using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDO.Data.EFModelCommon.Repos;

namespace EDO.Data.EFModelCommon
{
    public class EFApplicationUnit : IApplicationUnit
    {
        private EFDBContext _context = new EFDBContext();

        private IGenericRepository<UserProfile>     _profiles = null;
        private IGenericRepository<Business>        _businesses = null;
        private IGenericRepository<Office>          _offices = null;
        private IGenericRepository<Address>         _addresses = null;
        private IGenericRepository<UserPosition>    _positions = null;
        private IGenericRepository<AccountType>     _atypes = null;


        public IGenericRepository<UserProfile> UserProfiles
        {
            get
            {
                if(_profiles == null)
                {
                    _profiles = new EFGenericRepository<UserProfile>(_context);
                }

                return _profiles;
            }
        }

        public IGenericRepository<Business> Businesses
        {
            get
            {
                if (_businesses == null)
                {
                    _businesses = new EFGenericRepository<Business>(_context);
                }

                return _businesses;
            }
        }

        public IGenericRepository<Office> Offices
        {
            get
            {
                if (_offices == null)
                {
                    _offices = new EFGenericRepository<Office>(_context);
                }

                return _offices;
            }
        }

        public IGenericRepository<Address> Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new EFGenericRepository<Address>(_context);
                }

                return _addresses;
            }
        }

        public IGenericRepository<UserPosition> UserPositions
        {
            get
            {
                if (_positions == null)
                {
                    _positions = new EFGenericRepository<UserPosition>(_context);
                }

                return _positions;
            }
        }

        public IGenericRepository<AccountType> AccountTypes
        {
            get
            {
                if (_atypes == null)
                {
                    _atypes = new EFGenericRepository<AccountType>(_context);
                }

                return _atypes;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
