using Kestrel.EntityModel.Attachments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel;

namespace Kestrel.ViewModel
{
   public class MusicEntityViewModel :IEntityViewModel
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

        //创建时间
        public DateTime CreatTime { get; set; }


        //封面、音乐图片
        public virtual ICollection<BusinessImage> MusicImage { get; set; }

        //累计播放次数
        public int AddPlay { get; set; }

        //累计喜欢♥
        public int Addlike { get; set; }

        //累计赞👍

        public int AddThumb { get; set; }

        //累计踩👎
        public int AddTread { get; set; }
    }
}
