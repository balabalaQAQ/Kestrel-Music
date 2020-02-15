using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.ViewModels.ApplicationCommon.RoleAndUser
{
    /// <summary>
    /// 登录用户的在线信息，并且在 IViewModelService 提供相应的访问方法，用于在需要使用用户登录及关联的其它实体数据的元素.
    ///   1. OrganizationId：在获取的时候，对于: 
    ///      Employee  获取的是 LPFW.EntitiyModels.TransactionBusiness.OperationOrganization.DepartmentGroup 的 Id；
    ///      PurchaserEmployee 获取的是 PurchaserRegister 的 Id；
    ///      VenderEmployee 获取的是 VenderRegister 的 Id；
    ///   2. DepartmentId，在获取的时候，对于
    ///      Employee  获取的是 LPFW.EntitiyModels.TransactionBusiness.OperationOrganization.Department 的 Id；
    ///      PurchaserEmployee 获取的是 PurchaserDepartment 的 Id；
    ///      VenderEmployee 获取的是 VenderDepartment 的 Id；
    /// 在具体的方法中再根据方法处理的对象，获取相应的值，例如在采购订单中，
    /// 肯定会关联下单的用户，在获取这个模型对象数据后，需要自己再处理：
    ///   1. 根据 OrganizationId 获取采购商 VenderRegister 对象；
    ///   2. 根据 DepartmentId 获取采购商的内部部门 PurchaserDepartment 对象；
    ///   3. 根据 Id 获取采购商下单员工 PurchaserEmployee 对象。
    /// </summary>
    public class UserOnlineInformationVM
    {
        public Guid Id { get; set; }                   // 登录用户 Id
        public string UserName { get; set; }           // 登录的用户名
        public string Name { get; set; }               // 登录的用户显示名称
        public string MasterRoleId { get; set; }       // 宿主角色组 Id
        public string OrganizationId { get; set; }     // 用户归属单位 Id
        public string DepartmentId { get; set; }       // 用户归属的单位部门 Id

        public List<RoleItem> RoleIemtCollection { get; set; }   // 加载归属角色组基本信息的

        /// <summary>
        /// 简单的内嵌类，用于承载用户归属的角色组
        /// </summary>
        public class RoleItem
        {
            public Guid RoleID { get; set; }
            public string RoleName { get; set; }
        }

    }

    
}
