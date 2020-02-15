


using Kestrel.EntityModel.Tools;
using Kestrel.EntityModel.Users;
using Kestrel.ViewModels.ControlModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel;

namespace Kestrel.ViewModels.ApplicationCommon.RoleAndUser
{
    public class ApplicationRoleVM:EntityViewModel
    {
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        [Display(Name = "上级角色")]
        public string ParentRoleId { get; set; }
        [Display(Name = "上级角色")]
        public string ParentRoleName { get; set; }
        public List<SelfReferentialItem> ParentRoleItemCollection { get; set; }

        public ApplicationRoleVM()
        {
            this.ID = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<Role>();
        }

    }
}
