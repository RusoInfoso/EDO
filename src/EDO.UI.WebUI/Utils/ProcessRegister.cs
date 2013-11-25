using EDO.Model.Common.Abstract.Repositories;
using EDO.Model.Common.Entities;
using EDO.UI.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Utils
{
    public class ProcessRegister
    {
        private RegistrationViewModel _regViewModel;
        private IUserProfilesRepository _repository;

        private UserProfile _userProfile;

        public ProcessRegister(IUserProfilesRepository repository, RegistrationViewModel regViewModel)
        {
            _repository = repository;
            _regViewModel = regViewModel;
        }


    }
}