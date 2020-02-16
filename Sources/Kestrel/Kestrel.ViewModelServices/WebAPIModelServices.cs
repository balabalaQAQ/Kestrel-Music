using Kestrel.DataAccess;
using Kestrel.DataAccess.Tools;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.ViewModels.ApplicationCommon.RoleAndUser;
using Kestrel.ViewModels.ControlModels;
using Kestrel.ViewModelServices.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Kestrel.ViewModelServices
{
    public class WebAPIModelService<TEntity, TViewModel> : IWebAPIModelService<TEntity, TViewModel>
       where TEntity : class, IEntity, new()
       where TViewModel : class, IEntityViewModel, new()
    {
        private readonly IEntityRepository<TEntity> _entityRepository;

        public IEntityRepository<TEntity> EntityRepository
        {
            get { return _entityRepository; }
        }

        public WebAPIModelService(IEntityRepository<TEntity> entityRepository)
        {
            this._entityRepository = entityRepository;
        }

        public virtual async Task<TViewModel> GetBoVMAsyn(Guid id)
        {
            var isNew = false;
            var bo = await _entityRepository.GetBoAsyn(id);
            if (bo == null)
            {
                bo = new TEntity();
                isNew = true;
            }
            var boVM = new TViewModel();
            boVM.IsNew = isNew;

            // 映射基本属性值
            bo.MapToViewModel<TEntity, TViewModel>(boVM);
            return boVM;
        }

        public virtual async Task<TViewModel> GetBoVMAsyn(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var bo = await _entityRepository.GetBoAsyn(id, includeProperties);
            var boVM = new TViewModel();

            bo.MapToViewModel<TEntity, TViewModel>(boVM);

            return boVM;
        }

        public virtual async Task<List<TViewModel>> GetBoVMCollectionAsyn()
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn();
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public virtual async Task<List<TViewModel>> GetBoVMCollectionAsyn(string keyword)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(keyword);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public virtual async Task<List<TViewModel>> GetBoVMCollectionAsyn(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(includeProperties);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public virtual async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter)
        {
            var boCollection = await _entityRepository.GetBoPaginateAsyn(listPageParameter);
            var boVMCollection = new List<TViewModel>();

            // 初始化视图模型起始序号
            int count = (int.Parse(listPageParameter.PageIndex) - 1) * int.Parse(listPageParameter.PageSize);
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public virtual async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoPaginateAsyn(listPageParameter, includeProperties);
            var boVMCollection = new List<TViewModel>();
            // 初始化视图模型起始序号
            int count = (int.Parse(listPageParameter.PageIndex) - 1) * int.Parse(listPageParameter.PageSize);
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoPaginateAsyn(listPageParameter, navigatorPredicate, includeProperties);
            var boVMCollection = new List<TViewModel>();
            // 初始化视图模型起始序号
            int count = (int.Parse(listPageParameter.PageIndex) - 1) * int.Parse(listPageParameter.PageSize);
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }


        public async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter, includeProperties);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, Expression<Func<TEntity, object>> includeProperty)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter, navigatorPredicate, includeProperty);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter, navigatorPredicate, includeProperties);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }


        public async Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn()
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn();
            var selfReferentialItemCollection = SelfReferentialItemFactory<TEntity>.GetCollection(boCollection.ToList(), true);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection.OrderBy(x => x.SortCode))
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                var sItem = selfReferentialItemCollection.FirstOrDefault(x => x.ID == item.ID.ToString());
                if (sItem != null)
                    boVM.Name = sItem.DisplayName;

                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter);
            var selfReferentialItemCollection = SelfReferentialItemFactory<TEntity>.GetCollection(boCollection.ToList(), true);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection.OrderBy(x => x.SortCode))
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                var sItem = selfReferentialItemCollection.FirstOrDefault(x => x.ID == item.ID.ToString());
                if (sItem != null)
                    boVM.Name = sItem.DisplayName;
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }
        public async Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter, includeProperties);
            var selfReferentialItemCollection = SelfReferentialItemFactory<TEntity>.GetCollection(boCollection.ToList(), true);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection.OrderBy(x => x.SortCode))
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                var sItem = selfReferentialItemCollection.FirstOrDefault(x => x.ID == item.ID.ToString());
                if (sItem != null)
                    boVM.Name = sItem.DisplayName;
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }
        public async Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, Expression<Func<TEntity, object>> includeProperty)
        {
            var boCollection = await _entityRepository.GetBoCollectionAsyn(listPageParameter, navigatorPredicate, includeProperty);
            var selfReferentialItemCollection = SelfReferentialItemFactory<TEntity>.GetCollection(boCollection.ToList(), true);
            var boVMCollection = new List<TViewModel>();
            int count = 0;
            foreach (var item in boCollection.OrderBy(x => x.SortCode))
            {
                var boVM = new TViewModel();
                item.MapToViewModel<TEntity, TViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                var sItem = selfReferentialItemCollection.FirstOrDefault(x => x.ID == item.ID.ToString());
                if (sItem != null)
                    boVM.Name = sItem.DisplayName;
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<TOtherViewModel> GetOtherBoVM<TOrther, TOtherViewModel>(Guid id)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new()
        {
            var isNew = false;
            var bo = await _entityRepository.GetOtherBoAsyn<TOrther>(id);
            if (bo == null)
            {
                bo = new TOrther();
                isNew = true;
            }
            var boVM = new TOtherViewModel();
            boVM.IsNew = isNew;

            // 映射基本属性值
            bo.MapToViewModel<TOrther, TOtherViewModel>(boVM);
            return boVM;

        }

        /// <summary>
        /// 根据实体模型类型 TOrther，获取对应类型 TOtherViewModel 的视图模型对象集合
        /// </summary>
        /// <typeparam name="TOrther"></typeparam>
        /// <typeparam name="TOtherViewModel"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>()
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new()
        {
            var boCollection = await _entityRepository.GetOtherBoCollectionAsyn<TOrther>();
            var boVMCollection = new List<TOtherViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TOtherViewModel();
                item.MapToViewModel<TOrther, TOtherViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;

        }

        public async Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>(Expression<Func<TOrther, bool>> predicate)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new()
        {
            var boCollection = await _entityRepository.GetOtherBoCollectionAsyn<TOrther>(predicate);
            var boVMCollection = new List<TOtherViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TOtherViewModel();
                item.MapToViewModel<TOrther, TOtherViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }

        public async Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>(Expression<Func<TOrther, bool>> predicate, params Expression<Func<TOrther, object>>[] includeProperties)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new()
        {
            var boCollection = await _entityRepository.GetOtherBoCollectionAsyn<TOrther>(predicate, includeProperties);
            var boVMCollection = new List<TOtherViewModel>();
            int count = 0;
            foreach (var item in boCollection)
            {
                var boVM = new TOtherViewModel();
                item.MapToViewModel<TOrther, TOtherViewModel>(boVM);
                boVM.OrderNumber = (++count).ToString();
                boVMCollection.Add(boVM);
            }

            return boVMCollection;
        }


        public virtual async Task<SaveStatusModel> SaveBoAsyn(TViewModel boVM)
        {
            var bo = await _entityRepository.GetBoAsyn(boVM.ID);
            if (bo == null)
                bo = new TEntity();

            boVM.MapToEntityModel<TViewModel, TEntity>(bo);

            var saveStatus = await _entityRepository.SaveBoAsyn(bo);

            return saveStatus;
        }

        public virtual async Task<DeleteStatusModel> DeleteBoAsyn(Guid id)
        {
            var deleteStatus = await _entityRepository.DeleteBoAsyn(id);
            return deleteStatus;
        }

        public virtual async Task<bool> IsUnique(Expression<Func<TEntity, bool>> uniquePredicate)
        {
            return !await _entityRepository.HasBoAsyn(uniquePredicate);
        }

        public virtual async Task<List<TreeNodeForJsTree>> GetTreeViewNodeForJsTreeCollectionAsyn<SelfReferentialEntity>(Expression<Func<SelfReferentialEntity, object>> includeProperty) where SelfReferentialEntity : class, IEntity, new()
        {
            // 提取 <SelfReferentialEntity> 数据集合
            var selfReferentialEntityCollection = await _entityRepository.EntitiesContext.Set<SelfReferentialEntity>().Include(includeProperty).OrderBy(x => x.SortCode).ToListAsync();
            // 转换为 SelfReferentialItem 集合
            var selfReferentialItemCollection = SelfReferentialItemFactory<SelfReferentialEntity>.GetCollection(selfReferentialEntityCollection, false);

            // 构建树节点集合
            var result = TreeViewFactoryForJsTree.GetTreeNodes(selfReferentialItemCollection);

            return result;
        }

        public virtual async Task<List<TreeNodeForBootStrapTreeView>> GetTreeViewNodeForBootStrapTreeViewCollectionAsyn<SelfReferentialEntity>(Expression<Func<SelfReferentialEntity, object>> includeProperty) where SelfReferentialEntity : class, IEntity, new()
        {
            // 提取 <SelfReferentialEntity> 数据集合
            var selfReferentialEntityCollection = await _entityRepository.EntitiesContext.Set<SelfReferentialEntity>().Include(includeProperty).OrderBy(x => x.SortCode).ToListAsync();
            // 转换为 SelfReferentialItem 集合
            var selfReferentialItemCollection = SelfReferentialItemFactory<SelfReferentialEntity>.GetCollection(selfReferentialEntityCollection, false);

            // 构建树节点集合
            var result = TreeViewFactoryForBootSrapTreeView.GetTreeNodes(selfReferentialItemCollection);

            return result;

        }

        public virtual async Task<List<TreeNodeForBootStrapTreeView>> GetTreeViewNodeForBootStrapTreeViewCollectionAsyn<SelfReferentialEntity>(
            Expression<Func<SelfReferentialEntity, bool>> predicate,
            Expression<Func<SelfReferentialEntity, object>> includeProperty)
            where SelfReferentialEntity : class, IEntity, new()
        {
            // 提取 <SelfReferentialEntity> 数据集合
            var selfReferentialEntityCollection = await _entityRepository.EntitiesContext.Set<SelfReferentialEntity>().Include(includeProperty).Where(predicate).OrderBy(x => x.SortCode).ToListAsync();
            // 转换为 SelfReferentialItem 集合
            var selfReferentialItemCollection = SelfReferentialItemFactory<SelfReferentialEntity>.GetCollection(selfReferentialEntityCollection, false);

            // 构建树节点集合
            var result = TreeViewFactoryForBootSrapTreeView.GetTreeNodes(selfReferentialItemCollection);

            return result;

        }



        //public virtual async Task<UserOnlineInformationVM> GetUserOnlineInformationVM(string userName)
        //{
        //    var userOnlineInformationVM = new UserOnlineInformationVM();

        //    // 1. 获取用户并初始化 userOnlineInformationVM
        //    var user = await _entityRepository.ApplicationUserManager.FindByNameAsync(userName);
        //    userOnlineInformationVM.Id = user.ID;
        //    userOnlineInformationVM.Name = user.Name;
        //    userOnlineInformationVM.UserName = user.UserName;

        //    userOnlineInformationVM.MasterRoleId = "";
        //    userOnlineInformationVM.OrganizationId = "";
        //    userOnlineInformationVM.DepartmentId = "";
        //    userOnlineInformationVM.RoleIemtCollection = new List<UserOnlineInformationVM.RoleItem>();

        //    // 2. 获取用户 Claims
        //    var userClaimCollection = await _entityRepository.ApplicationUserManager.GetClaimsAsync(user);
        //    // 2.1. 处理用户关联的宿主角色数据
        //    var roleClaim = userClaimCollection.FirstOrDefault(x => x.Type == "宿主角色组");
        //    if (roleClaim != null)
        //        userOnlineInformationVM.MasterRoleId = (roleClaim.Value);
        //    // 2.2. 处理用户关联的单位数据
        //    var organizationClaim = userClaimCollection.FirstOrDefault(x => x.Type == "宿主单位");
        //    if (organizationClaim != null)
        //        userOnlineInformationVM.OrganizationId = organizationClaim.Value;
        //    // 2.3. 处理关联的部门数据
        //    var departmentClaim = userClaimCollection.FirstOrDefault(x => x.Type == "宿主部门");
        //    if (departmentClaim != null)
        //        userOnlineInformationVM.DepartmentId = departmentClaim.Value;

        //    // 3. 处理关联的角色组
        //    var roleNameCollection = await _entityRepository.ApplicationUserManager.GetRolesAsync(user);
        //    foreach (var roleName in roleNameCollection)
        //    {
        //        var role = await _entityRepository.ApplicationRoleManager.FindByNameAsync(roleName);
        //        var roleItem = new UserOnlineInformationVM.RoleItem() { RoleID = role.ID, RoleName = role.Name };
        //        userOnlineInformationVM.RoleIemtCollection.Add(roleItem);
        //    }

        //    return userOnlineInformationVM;
        //}
    }
}
