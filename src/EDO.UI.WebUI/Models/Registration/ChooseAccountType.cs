using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    [Serializable]
    public class AccountTypeVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }

    [Serializable]
    public class ChooseAccountType : IRegistrationStepVM
    {
        [Required]
        public string AccountTypeCode { get; set; }
        public List<AccountTypeVM> AccountTypesList { get; set; }
        
        public ChooseAccountType()
        {
            AccountTypesList = new List<AccountTypeVM>
            {
                new AccountTypeVM
                {
                    Id = 1,
                    Title = "Индивидуальный предприниматель",
                    Code = "individual"
                },
                new AccountTypeVM
                {
                    Id = 2,
                    Title = "Организация",
                    Code = "business"
                },
                new AccountTypeVM
                {
                    Id = 3,
                    Title = "Физическое лицо",
                    Code = "private"
                }
            };

            AccountTypeCode = AccountTypesList[0].Code;
        }
    }
}