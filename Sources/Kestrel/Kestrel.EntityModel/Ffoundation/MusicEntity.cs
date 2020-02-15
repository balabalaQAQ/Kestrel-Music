
using Kestrel.EntityModel.Attachments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Ffoundation
{
    public class MusicEntity : IMusicEntity
    {
     
        [Key]
        public Guid ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

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
