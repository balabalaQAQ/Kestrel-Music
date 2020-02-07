using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
   public class EntityViewModel:IEntityViewModel
    {
        public Guid ID { get; set; }
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
        public bool IsNew { get; set; }
        public bool IsSaved { get; set; }
        public bool IsCurrent { get; set; }// 是否当前对象 
        public string ErrorMessage { get; set; }

        [Required(ErrorMessage = "名称不能为空值。")]
        [Display(Name = "名称")]
        [StringLength(100, ErrorMessage = "你输入的数据超出限制100个字符的长度。")]
        public virtual string Name { get; set; }

        [Display(Name = "简要说明")]
        [StringLength(1000, ErrorMessage = "你输入的数据超出限制1000个字符的长度。")]
        public virtual string Description { get; set; }

        //[Required(ErrorMessage = "业务编码不能为空值。")]
        //[Display(Name = "业务编码")]
        //[StringLength(150, ErrorMessage = "你输入的数据超出限制150个字符的长度。")]
        public virtual string SortCode { get; set; }
    }
}
