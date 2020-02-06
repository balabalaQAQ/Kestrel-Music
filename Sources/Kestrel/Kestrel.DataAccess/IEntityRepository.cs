using Kestrel.EntityModel.Ffoundation;
using Kestrel.ORM;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kestrel.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntityBase,new()
    {
        KestrelDbcontext EntitiesContext { get; set; }

        #region 1.获取指定类型实体数据对象数量的方法，2个重载
        /// <summary>
        /// 获取指定类型 T 的集合元素数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetBoAmountAsyn();

        Task<int> GetBoAmountAsyn(Expression<Func<T, bool>> predicate);

        #endregion
        #region 2.常规获取指定类型 T 单个实体对象的方法，4个重载

        /// <summary>
        /// 获取指定类型 T 集合元素的第一个
        /// </summary>
        /// <returns></returns>
        Task<T> GetBoAsyn();

        /// <summary>
        /// 根据对象的 Id 值获取类型 T 的单个业务对象
        /// </summary>
        /// <param name="id">业务对象 Id 的值</param>
        /// <returns></returns>
        Task<T> GetBoAsyn(Guid id);



        /// <summary>
        /// 根据对象的 Id 值和指定的对象实体模型中的关联实体参数，获取类型 T 的单个业务对象，同时包含了关联对象的值
        /// </summary>
        /// <param name="id">业务对象 Id 的值</param>
        /// <param name="includeProperties">业务对象模型中指定关联的实体属性的 Lamabda 表达式，例如：x=x.Name,... </param>
        /// <returns></returns>
        Task<T> GetBoAsyn(Guid id, params Expression<Func<T, object>>[] includeProperties);



        /// <summary>
        /// 根据 Lambda 表达式的条件，获取满足条件的类型 T 集合元素的第一个元素
        /// </summary>
        /// <param name="predicate">使用 Lambada 表达式提交的查询条件</param>
        /// <returns></returns>
        Task<T> GetBoAsyn(Expression<Func<T, bool>> predicate);
        #endregion

    }
}
