using Kestrel.DataAccess.Tools;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.ViewModelServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Kestrel.WebApi.BaseControllers
{
    public class BaseTemplateController<TEntity, TViewModel> : Controller
          where TEntity : class, IEntity, new()
        where TViewModel : class, IEntityViewModel, new()
    {

        // 列表页处理（检索、排序、类别）所需要的参数
        public ListPageParameter PaginateListPageParameter = new ListPageParameter(1, 18);
        public ListSinglePageParameter NoPaginateListPageParameter = new ListSinglePageParameter();


        // 导航类型的实体模型名称，在使用到导航页模板的时候，派生控制器必须设置这个参数
        public string TypeName;

        // 实体模型和视图数据服务访问处理服务
        private readonly IWebAPIModelService<TEntity, TViewModel> _viewModelService;
        // 公开的实体模型和视图数据服务访问处理服务，便于继承于这个控制器的派生控制器使用
        public IWebAPIModelService<TEntity, TViewModel> ViewModelService { get { return _viewModelService; } }

    }
}