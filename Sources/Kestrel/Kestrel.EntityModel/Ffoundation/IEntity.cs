using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Ffoundation
{
   public interface IEntity:IEntityBase
    {
        //名称
        string Name { get; set; }

        //说明
        string Description { get; set; }

        //业务编码
        string SortCode { get; set; }

        //伪删除
        bool IsPseudoDelete{ get; set; }


    }
}
