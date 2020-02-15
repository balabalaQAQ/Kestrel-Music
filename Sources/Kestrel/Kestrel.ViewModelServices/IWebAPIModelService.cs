using Kestrel.DataAccess;
using Kestrel.DataAccess.Tools;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.ViewModels.ControlModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModel;
 

namespace Kestrel.ViewModelServices
{

    public interface IWebAPIModelService<TEntity, TViewModel>
           where TEntity : class, IEntity, new()
           where TViewModel : class, IEntityViewModel, new()
    {
        /// <summary>
        /// 数据访问仓储服务
        /// </summary>
        IEntityRepository<TEntity> EntityRepository { get; }

        /// <summary>
        /// 根据传入的实体模型的 id 的值，创建和返回一个视图模型对象，如果在实体对象不存在相应 id 的对象，则返回一个带有空数据视图模型对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TViewModel> GetBoVMAsyn(Guid id);
        Task<TViewModel> GetBoVMAsyn(Guid id, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// 返回视图模型集合
        /// </summary>
        /// <returns></returns>
        Task<List<TViewModel>> GetBoVMCollectionAsyn();
        Task<List<TViewModel>> GetBoVMCollectionAsyn(string keyword);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// 根据分页模型数据，返回分页数据处理结果
        /// </summary>
        /// <param name="listPageParameter"></param>
        /// <returns></returns>
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListPageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, params Expression<Func<TEntity, object>>[] includeProperty);

        /// <summary>
        /// 根据单页数据模型，返回处理结果
        /// </summary>
        /// <param name="listPageParameter"></param>
        /// <returns></returns>
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, Expression<Func<TEntity, object>> includeProperty);
        Task<List<TViewModel>> GetBoVMCollectionAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// 获取视图模型，并且将视图模型集合设置为带有层次形式外观的集合
        /// </summary>
        /// <returns></returns>
        Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn();
        Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter);
        Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TViewModel>> GetBoVMCollectionWithHierarchicalStyleAsyn(ListSinglePageParameter listPageParameter, Expression<Func<TEntity, bool>> navigatorPredicate, Expression<Func<TEntity, object>> includeProperty);

        /// <summary>
        /// 根据实体模型类型 TOrther 和其数据对象的 id，获取对应类型 TOtherViewModel 的视图模型对象
        /// </summary>
        /// <typeparam name="TOrther"></typeparam>
        /// <typeparam name="TOtherViewModel"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TOtherViewModel> GetOtherBoVM<TOrther, TOtherViewModel>(Guid id)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new();

        /// <summary>
        /// 根据实体模型类型 TOrther，获取对应类型 TOtherViewModel 的视图模型对象集合
        /// </summary>
        /// <typeparam name="TOrther"></typeparam>
        /// <typeparam name="TOtherViewModel"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>()
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new();

        Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>(Expression<Func<TOrther, bool>> predicate)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new();

        Task<List<TOtherViewModel>> GetOtherBoVMCollection<TOrther, TOtherViewModel>(Expression<Func<TOrther, bool>> predicate, params Expression<Func<TOrther, object>>[] includeProperties)
            where TOrther : class, IEntity, new()
            where TOtherViewModel : class, IEntityViewModel, new();

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="boVM"></param>
        /// <returns></returns>
        Task<SaveStatusModel> SaveBoAsyn(TViewModel boVM);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DeleteStatusModel> DeleteBoAsyn(Guid id);

        /// <summary>
        /// 唯一性判断,返回 true 表示唯一，false 表示已经存在了
        /// </summary>
        /// <param name="uniquePredicate">判断条件的 Lambda 表达式</param>
        /// <returns></returns>
        Task<bool> IsUnique(Expression<Func<TEntity, bool>> uniquePredicate);


        /// <summary>
        /// 获取用于导航树插件 BootStrap-TreeView 节点数据集合的方法
        /// </summary>
        /// <typeparam name="SelfReferentialEntity">具有自引用关系而且继承自 IEntity 的实体模型类型</typeparam>
        /// <returns></returns>
        Task<List<TreeNodeForBootStrapTreeView>> GetTreeViewNodeForBootStrapTreeViewCollectionAsyn<SelfReferentialEntity>(Expression<Func<SelfReferentialEntity, object>> includeProperty) where SelfReferentialEntity : class, IEntity, new();
        Task<List<TreeNodeForBootStrapTreeView>> GetTreeViewNodeForBootStrapTreeViewCollectionAsyn<SelfReferentialEntity>(Expression<Func<SelfReferentialEntity, bool>> predicate, Expression<Func<SelfReferentialEntity, object>> includeProperty) where SelfReferentialEntity : class, IEntity, new();

    }
}

