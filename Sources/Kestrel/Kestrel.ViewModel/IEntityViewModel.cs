using Kestrel.EntityModel.Ffoundation;
using System;

namespace ViewModel
{
    public interface IEntityViewModel : IEntityBase
    {
        string Name { get; set; }
        string Description { get; set; }
        string SortCode { get; set; }

        #region 附加的常规属性，用于前端处理表现和一些状态
        string OrderNumber { get; set; }          // 列表时候需要的序号
        bool IsNew { get; set; }                  // 是否是新创建的对象，要特别注意在实际使用时候的赋值
        bool IsSaved { get; set; }                // 新建或者编辑对象时候，提交保存成功的状态，要特别注意在实际使用时候的赋值
        bool IsCurrent { get; set; }              // 是否当前对象 
        string ErrorMessage { get; set; }  // 视图模型处理错误信息 

        #endregion
    }
}
